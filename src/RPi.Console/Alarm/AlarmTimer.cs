using System;
using System.Threading;
using System.Timers;
using Common.Logging;
using Timer = System.Timers.Timer;

namespace RPi.ConsoleApp
{
    class AlarmTimer
    {
        readonly Timer _timer;
        private readonly AutoResetEvent _waitHandle;
        private DateTime _alarmTime;
        private int _lastMinute;
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();


        public AlarmTimer()
        {
            // todo: implement dispose
            _waitHandle = new AutoResetEvent(false);

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.AutoReset = true;
        }

        public void WaitUntil(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
            _waitHandle.WaitOne();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now >= _alarmTime)
            {
                Log.InfoFormat("The alarm is raised! Time={0}, Alarm={1}", DateTime.Now, _alarmTime);
                _timer.Stop();
                _waitHandle.Set();
            }
            
            var currentMinute = DateTime.Now.Minute;
            if (currentMinute != _lastMinute)
            {
                Log.Info(currentMinute % 2 == 0 ? "Tick" : "Tock");
            }

            _lastMinute = currentMinute;
        }
    }
}