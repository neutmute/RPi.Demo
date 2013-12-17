using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using RPi.Pwm;

namespace RPi.ConsoleApp
{
    class AlarmClock
    {
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();
        private PwmController _pwmController;
        private DateTime _alarmTime;

        public AlarmClock(PwmController pwmController)
        {
            _pwmController = pwmController;
        }

        public void Set(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
            Log.InfoFormat("Time is {1}, alarm set to {0}", _alarmTime, DateTime.Now);
        }

        public void Set(TimeSpan timeSpan)
        {
            Set(DateTime.Now + timeSpan);
        }

        public void WaitForAlarm()
        {
            var alarmTimer = GetWaitTask();
            var ledPulser = GetLedPulserTask();
            ledPulser.Start();
            alarmTimer.Start();
            Task.WaitAll(alarmTimer);
            
            ActivateAlarm();
        }

        private Task GetWaitTask()
        {
            var alarmTimerTask = new Task(
                () => 
                {
                    var timer = new AlarmTimer();
                    timer.WaitUntil(_alarmTime);
                }
                );
            return alarmTimerTask;
        }

        private Task GetLedPulserTask()
        {
            var pulserTask = new Task(
                () =>
                {
                    int i = 0;
                    while (i < int.MaxValue)
                    {
                        i++;
                        var percentage = (int) (50*(1 + Math.Sin( i / 20f )));
                        _pwmController.Led0.On(percentage);   
                        Thread.Sleep(50);
                    }
                }
                );
            return pulserTask;
        }


        private void ActivateAlarm()
        {
            Log.Info("Jingle Bells!");
            _pwmController.DcMotor.Go(100);
            Thread.Sleep(10000);
        }
    }
}
