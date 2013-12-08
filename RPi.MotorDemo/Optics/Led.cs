using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raspberry.IO.Components.Expanders.Pca9685;
using RPi.MotorDemo.Motors;

namespace RPi.MotorDemo
{
    public class Led : PwmComponentBase
    {
        private readonly PwmChannel _channel;

        public Led(IPwmDevice controller, PwmChannel channel)
            : base(controller)
        {
            _channel = channel;
        }

        public void On(int percent)
        {
            var percentAsPwm = GetPercentAsPwm(percent);
            Log.Info("Led{0}={1}", _channel, percent);
            Controller.SetPwm(_channel, 0, percentAsPwm);
        }

        public void On()
        {
            Log.Info("Led{0}=on", _channel);
            Controller.SetFull(_channel, true);
        }

        public void Off()
        {
            Log.Info("Led{0}=off", _channel);
            Controller.SetFull(_channel, false);
        }
    }
}
