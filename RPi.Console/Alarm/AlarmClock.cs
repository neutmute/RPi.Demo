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
            var t = GetWaitTask();
            t.Start();
            Task.WaitAll(t);
            ActivateAlarm();
        }

        private Task GetWaitTask()
        {
            var t = new Task(
                () => {
                    var timer = new AlarmTimer();
                    timer.WaitUntil(_alarmTime);
                }
                );
            return t;
        }

        private void ActivateAlarm()
        {
            Log.Info("Jingle Bells!");
            _pwmController.DcMotor.Go(100);
            Thread.Sleep(10000);
        }
    }
}
