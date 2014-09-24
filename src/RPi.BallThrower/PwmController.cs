using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.InterIntegratedCircuit;
using RPi.Comms;
using RPi.Pwm.Motors;
using RPi.Pwm.Optics;
using PwmChannel = Raspberry.IO.Components.Controllers.Pca9685.PwmChannel;

namespace RPi.Pwm
{
    public class PwmController : PwmControlBase
    {

        public ServoMotor Servo { get; private set; }

        public DcMotor DcMotor { get; private set; }
        public Led Led0 { get; private set; }

        public StepperMotor Stepper { get; private set; }


        public event EventHandler OnStepperCompleted;


        public PwmController(IPwmDevice pwmDevice)
            : base(pwmDevice)
        {
        }

        public void Init()
        {
            Servo = new ServoMotor(PwmDevice, PwmChannel.C1, 150, 600);
            DcMotor = new DcMotor(PwmDevice, PwmChannel.C4, PwmChannel.C5);

            Stepper = new StepperMotor(
                PwmDevice
                , PwmChannel.C11
                , PwmChannel.C10
                , PwmChannel.C9
                , PwmChannel.C8);

            Stepper.RotationCompleted += OnStepperCompleted;

            Led0 = new Led(PwmDevice, PwmChannel.C0);
        }

        public void AllStop()
        {
            Log.Info("All stop");
            Led0.Off();
            DcMotor.Stop();
        }

        public void Command(int channel, int percent)
        {
            Servo.MoveTo(percent);
        }

        public void Command(PwmCommand pwmCommand)
        {
            Log.DebugFormat("PwmCommand received({0})!", pwmCommand);
            switch (pwmCommand.Channel)
            {
                case DeviceChannel.DcMotor:
                    var percent = pwmCommand.DutyCyclePercent;
                    var direction = percent > 0 ? MotorDirection.Forward : MotorDirection.Reverse;
                    DcMotor.Go(Math.Abs(percent), direction);
                    break;
                case DeviceChannel.Led:
                    Led0.On(pwmCommand.DutyCyclePercent);
                    break;
                case DeviceChannel.Servo:
                    Servo.MoveTo(pwmCommand.DutyCyclePercent);
                    break;
            }
        }


        public void Command(StepperCommand command)
        {
            Log.InfoFormat("StepperCommand received({0})!", command);
            Stepper.StepDelayMs = command.DelayMs;
            Stepper.Rotate(command.Steps);
        }


    }
}
