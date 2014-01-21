using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raspberry.IO.Components.Controllers.Pca9685;

namespace RPi.Pwm.Motors
{
    public enum MotorDirection
    {
        Forward = 1,
        Reverse = -1
    }

    public class DcMotor : PwmComponentBase
    {
        private readonly PwmChannel _controlChannel0;
        private readonly PwmChannel _controlChannel1;

        

        /// <summary>
        /// Assumes a SN754410 or equivalent wired to the PWM channels
        /// </summary>
        public DcMotor(IPwmDevice controller, PwmChannel controlChannel0, PwmChannel controlChannel1)
            : base(controller)
        {
            _controlChannel0 = controlChannel0;
            _controlChannel1 = controlChannel1;
        }
        
        public void Go(int powerPercent, MotorDirection direction = MotorDirection.Forward)
        {
            var speedInPwm = GetPercentAsPwm(powerPercent);

            var channelA = direction == MotorDirection.Forward ? _controlChannel0 : _controlChannel1;
            var channelB = direction == MotorDirection.Forward ? _controlChannel1 : _controlChannel0;

            if (powerPercent == 100)
            {
                Log.Debug(m => m("DC.{0}={2}.{1} (FULL)", channelA, powerPercent, direction));
                Controller.SetFull(channelA, true);
                Controller.SetFull(channelB, false);
            }
            else if (powerPercent == 0)
            {
                Log.Debug(m=>m("DC.{0}={2}.{1} (FULL OFF)", channelA, powerPercent, direction));
                Controller.SetFull(channelA, false);
                Controller.SetFull(channelB, false);
            }
            else
            {
                Log.Debug(m => m("DC.{0}={3}.{1} (pwm={2})", channelA, powerPercent, speedInPwm, direction));
                Controller.SetPwm(channelA, 0, speedInPwm);
                Controller.SetFull(channelB, false);
            }
        }

        public void Stop()
        {
            Log.Debug(m => m("DC.{0}=FULL OFF", _controlChannel0));
            Controller.SetFull(_controlChannel0, false);
            Controller.SetFull(_controlChannel1, false);
        }
    }
}
