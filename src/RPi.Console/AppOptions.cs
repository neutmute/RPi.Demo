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
        AlarmClock,
        SignalRTest,
        SoundTest
    }

    public class ConsoleOptions
    {
        public Mode Mode { get; set; }

        public DateTime AlarmDate { get; set; }
        public bool UseFakeDevice { get; set; }
        public bool SignalRConnect { get; set; }

        public bool ShowHelp;

        public OptionSet OptionSet { get; private set; }

        public ConsoleOptions(string[] args)
        {
            OptionSet = new OptionSet {
                { "m|mode=",  v => Mode =(Mode) Enum.Parse(typeof(Mode), v)},
                { "nopcm",  v => UseFakeDevice=true},
                { "a|alarmdate=",  v => {AlarmDate =  DateTime.Parse(v); Mode = Mode.AlarmClock;}},
                { "t|alarmtime=",  v => {AlarmDate =  DateTime.Now + TimeSpan.Parse(v); Mode = Mode.AlarmClock;}},
                { "h|?:", v => ShowHelp = true }
            };
            OptionSet.Parse(args);
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            s.AppendFormat("Mode={0}", Mode);

            if (Mode == Mode.AlarmClock)
            {
                s.AppendFormat(", AlarmDate={1:yyyy-MM-dd HH:mm:ss}", Environment.NewLine, AlarmDate);
            }

            if (UseFakeDevice)
            {
                s.AppendFormat(", UseFakeDevice=true", Environment.NewLine);
            }
            return s.ToString();
        }

    }
}
