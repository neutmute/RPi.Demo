using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace RPi.NancyHost
{

    public class ConsoleOptions
    {
        public bool UseFakeDevice { get; set; }

        public bool ShowHelp;

        public OptionSet OptionSet { get; private set; }

        public ConsoleOptions(string[] args)
        {
            OptionSet = new OptionSet {
                { "f|usefake", "Use a mock device for PWM" , v => UseFakeDevice = true},
                { "h|?:", v => ShowHelp = true }
            };
            OptionSet.Parse(args);
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            s.AppendFormat("UseFakeDevice={0}", UseFakeDevice);
            
            return s.ToString();
        }

    }
}
