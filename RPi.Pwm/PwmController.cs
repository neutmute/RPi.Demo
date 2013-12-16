using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.InterIntegratedCircuit;
using RPi.Pwm.Motors;
using RPi.Pwm.Optics;

namespace RPi.Pwm
{
    public class PwmController
    {
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();

        public ServoMotor Servo { get; private set; }

        public DcMotor DcMotor { get; private set; }
        public Led Led0 { get; private set; }

        public StepperMotor Stepper { get; private set; }

        private readonly IPwmDevice _pwmDevice;

        public PwmController(IPwmDevice pwmDevice)
        {
            _pwmDevice = pwmDevice;
        }

        public void Init()
        {
            Servo = new ServoMotor(_pwmDevice, PwmChannel.C1, 150, 600);
            DcMotor = new DcMotor(_pwmDevice, PwmChannel.C4, PwmChannel.C5);
        
            Stepper = new StepperMotor(
                _pwmDevice
                , PwmChannel.C11
                , PwmChannel.C10
                , PwmChannel.C9
                , PwmChannel.C8);

            Led0 = new Led(_pwmDevice, PwmChannel.C0);
        }
        
        public void AllStop()
        {
            Log.Info("All stop");
            Led0.Off();
            DcMotor.Stop();
        }

    }
}
