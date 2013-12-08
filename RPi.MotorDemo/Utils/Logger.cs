using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPi.MotorDemo.Utils
{
    public class Logger
    {
        public void Info(string format, params object[] args)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {

                Console.WriteLine(format, args);
            }
            else
            {
                LogBus.Instance.Info(format, args);   
            }
        }
    }

    public class LogEvent: EventArgs
    {
        public string Message {get;set;}

    }

    public sealed class LogBus
    {
        private static readonly Lazy<LogBus> lazy =
            new Lazy<LogBus>(() => new LogBus());

        public static LogBus Instance { get { return lazy.Value; } }

        public event EventHandler<LogEvent> LogReceived;

        private LogBus()
        {
        }

        public void Info(string format, params object[] args)
        {
            var message = string.Format(format, args);
            Console.WriteLine(message);

            if (LogReceived != null)
            {
                LogReceived(this, new LogEvent {Message = message});
            }
        }
    }
}
