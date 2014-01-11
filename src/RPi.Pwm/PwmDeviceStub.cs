using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;

namespace RPi.Pwm
{
    public class PwmDeviceStub : IPwmDevice
    {
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();
        public void SetPwmUpdateRate(int frequencyHz)
        {
            Log.Debug(m => m("Stub:SetPwmUpdateRate({0})", frequencyHz));
        }

        public void SetPwm(PwmChannel channel, int on, int off)
        {
            Log.Info(m => m("Stub:SetPwm({0},{1},{2})", channel, on, off));
        }

        public void SetFull(PwmChannel channel, bool fullOn)
        {
            Log.Debug(m => m("Stub:SetPwm({0},{1})", channel, fullOn));
        }
    }
}
