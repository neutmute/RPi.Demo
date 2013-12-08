using Raspberry.IO.Components.Expanders.Pca9685;
using RPi.MotorDemo.Utils;

namespace RPi.MotorDemo.Motors
{
    public abstract class PwmComponentBase
    {

        private static readonly Logger _Log = new Logger();
        protected const int PwmMaximum = 4095;

        protected IPwmDevice Controller {get; private set;}
        protected Logger Log { get { return _Log; } }

        protected PwmComponentBase(IPwmDevice controller)
        {
            Controller = controller;
        }

        protected int GetCoercedPercent(int percent)
        {
            if (percent > 100)
            {
                percent = 100;
            }

            if (percent < 0)
            {
                percent = 0;
            }
            return percent;
        }

        protected int GetPercentAsPwm(int percent)
        {
            var coercedPercent = GetCoercedPercent(percent);
            var speedInPwm = coercedPercent * PwmMaximum / 100;
            return speedInPwm;
        }
    }
}