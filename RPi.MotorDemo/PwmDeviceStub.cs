using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raspberry.IO.Components.Controllers.Pca9685;
using Raspberry.IO.Components.Controllers.Pca9685;
using RPi.MotorDemo.Utils;

namespace RPi.MotorDemo
{
    public class PwmDeviceStub : IPwmDevice
    {
        private static readonly Logger Log = new Logger();
        public void SetPwmUpdateRate(int frequencyHz)
        {
            Log.Info("Stub:SetPwmUpdateRate({0})", frequencyHz);
        }

        public void SetPwm(PwmChannel channel, int on, int off)
        {
            Log.Info("Stub:SetPwm({0},{1},{2})", channel, on, off);
        }

        public void SetFull(PwmChannel channel, bool fullOn)
        {
            Log.Info("Stub:SetPwm({0},{1})", channel, fullOn);
        }
    }
}
