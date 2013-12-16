using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDesk.Options;

namespace RPi.ConsoleApp
{
    public enum Mode
    {
        Help = 0,
        DcMotor,
        Servo,
        Stepper,
        Led,
        RawPwm,
        AlarmClock
    }

    public class ConsoleOptions
    {
        public Mode Mode { get; set; }

        public DateTime AlarmDate { get; set; }
        public bool UseFakeDevice { get; set; }

        private bool _showHelp;

        public ConsoleOptions(string[] args)
        {
            var p = new OptionSet {
                { "m|mode=",  v => Mode =(Mode) Enum.Parse(typeof(Mode), v)},
                { "a|alarmdate=",  v => {AlarmDate = AlarmDate = DateTime.Parse(v); Mode = Mode.AlarmClock;}},
                { "f|usefake=",  v => {UseFakeDevice = bool.Parse(v);}},
                { "h|?:", v => _showHelp = true }
            };
            p.Parse(args);

            if (_showHelp)
            {
                Console.WriteLine("Options:");
                p.WriteOptionDescriptions(Console.Out);
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Mode={1}{0}AlarmDate={2:yyyy-MM-dd HH:mm:ss}{0}"
                , Environment.NewLine
                , Mode
                , AlarmDate
               );
        }

    }
}
