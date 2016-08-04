using System;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;


namespace RPi.Pwm.Motors
{
    public abstract class PwmComponentBase
    {

        private readonly static ILog _Log = LogManager.GetLogger< PwmComponentBase>();
        protected const int PwmMaximum = 4095;

        protected IPwmDevice Controller {get; private set;}
        protected ILog Log { get { return _Log; } }

        protected PwmComponentBase(IPwmDevice controller)
        {
            Controller = controller;
        }

        protected decimal GetCoercedPercent(decimal percent)
        {
            if (percent > 100)
            {
                percent = 100;
            }

            if (percent < 0)
            {
                percent = decimal.Zero;
            }
            return percent;
        }

        protected int GetPercentAsPwm(Decimal percent)
        {
            var coercedPercent = GetCoercedPercent(percent);
            var speedInPwm = (coercedPercent * PwmMaximum) / 100;
            return Convert.ToInt32(speedInPwm);
        }
    }
}