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

        public List<PwmChannel> LogChannels { get; private set; }

        public PwmDeviceStub()
        {
            LogChannels = new List<PwmChannel>();
            var oneToEleven = from n in Enumerable.Range(0, 11) select (PwmChannel) Enum.ToObject(typeof(PwmChannel), n);
            LogChannels.AddRange(oneToEleven);
        }

        public void SetPwmUpdateRate(int frequencyHz)
        {
            Log.Debug(m => m("Stub:SetPwmUpdateRate({0})", frequencyHz));
        }

        public void SetPwm(PwmChannel channel, int on, int off)
        {
            if (LogChannels.Contains(channel))
            {
                Log.Info(m => m("Stub:SetPwm({0},{1},{2})", channel, on, off));
            }
        }

        public void SetFull(PwmChannel channel, bool fullOn)
        {
            Log.Debug(m => m("Stub:SetPwm({0},{1})", channel, fullOn));
        }
    }
}
