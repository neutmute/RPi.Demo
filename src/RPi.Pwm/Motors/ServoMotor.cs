using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raspberry.IO.Components.Controllers.Pca9685;

namespace RPi.Pwm.Motors
{
    public class ServoMotor : PwmComponentBase
    {
        private int MaximumPosition { get; set; }

        private int MinimumPosition { get; set; }

        private PwmChannel Channel { get; set; }


        public ServoMotor(IPwmDevice controller, PwmChannel channel, int mimimum, int maximum): base(controller)
        {
            Channel = channel;
            MaximumPosition = maximum;
            MinimumPosition = mimimum;
        }

        public void MoveTo(int percent)
        {
            percent = GetCoercedPercent(percent);

            var gap = MaximumPosition -  MinimumPosition;
            var pulseValue = MinimumPosition + (gap*percent/100);
            Log.Debug(m=>m("Servo.{0} => {1}% (pulse={2})", Channel, percent, pulseValue));
            Controller.SetPwm(Channel, 0, pulseValue);
        }
    }
}
