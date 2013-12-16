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
        RawPwm
    }

    public class ConsoleOptions
    {
        public Mode Mode { get; set; }

        private bool _showHelp;

        public ConsoleOptions(string[] args)
        {
            var p = new OptionSet {
                { "m|mode=",  v => Mode =(Mode) Enum.Parse(typeof(Mode), v)},
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
                "Mode={1}{0}{0}"
                , Environment.NewLine
                , Mode
               );
        }

    }
}
