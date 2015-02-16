using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raspberry.IO.Components.Controllers.Pca9685;

namespace RPi.Pwm.Motors
{
    public interface IServoMotor
    {
        decimal CurrentPercent { get; }
        int CurrentPwm { get; }
        void MoveTo(decimal percent);
    }

    public class ServoMotor : PwmComponentBase, IServoMotor
    {
        private int MaximumPosition { get; set; }

        private int MinimumPosition { get; set; }

        public decimal CurrentPercent { get; private set; }
        public int CurrentPwm { get; private set; }

        private PwmChannel Channel { get; set; }


        public ServoMotor(IPwmDevice controller, PwmChannel channel, int mimimum, int maximum): base(controller)
        {
            Channel = channel;
            MaximumPosition = maximum;
            MinimumPosition = mimimum;
        }

        public void MoveTo(decimal percent)
        {
            percent = GetCoercedPercent(percent);

            var gap = MaximumPosition -  MinimumPosition;
            CurrentPwm = (int) (MinimumPosition + (gap * percent / 100));
            Log.Debug(m => m("Servo.{0} => {1}% (pulse={2})", Channel, percent, CurrentPwm));
            Controller.SetPwm(Channel, 0, CurrentPwm);
            CurrentPercent = percent;
        }

        public override string ToString()
        {
            return string.Format("Percent={0:F}", CurrentPercent);
        }
    }
}
