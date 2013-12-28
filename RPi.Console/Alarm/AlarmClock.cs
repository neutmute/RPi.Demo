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
        #region Fields

        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly PwmController _pwmController;
        private DateTime _alarmTime;
        private bool _alarmFired;

        #endregion


        #region Ctor

        public AlarmClock(PwmController pwmController)
        {
            _pwmController = pwmController;
        }

        #endregion


        #region Methods

        public void Set(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
            Log.InfoFormat("Time is {1}, alarm set to {0}", _alarmTime, DateTime.Now);
        }

        public void Set(TimeSpan timeSpan)
        {
            Set(DateTime.Now + timeSpan);
        }

        public async Task WaitForAlarm()
        {
            StartLedSignOfLifeAsync();
            var alarmTimer = StartAlarmTimerAsync();

            await alarmTimer;
            
            ActivateAlarm();
        }

        private async Task StartAlarmTimerAsync()
        {
            var timer = new AlarmTimer();
            timer.WaitUntil(_alarmTime);
        }

        private async Task StartLedSignOfLifeAsync()
        {
            int i = 0;
            Log.Info("Sign of life: on");
            while (!_alarmFired && i < int.MaxValue)
            {
                i++;
                var percentage = (int) (50*(1 + Math.Sin(i/20f)));
                _pwmController.Led0.On(percentage);
                await Task.Delay(50).ConfigureAwait(false);
            }
            Log.Info("Sign of life: off");
        }


        private void ActivateAlarm()
        {
            var bellsRunFor = TimeSpan.FromSeconds(10);
            _alarmFired = true;
            Log.Info("Jingle Bells!");
            _pwmController.DcMotor.Go(100);
            Thread.Sleep(bellsRunFor);
            Log.InfoFormat("Jingle Bell ran for {0}s!", bellsRunFor.TotalSeconds);
        }

        #endregion

    }
}
