using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Raspberry.IO.Components.Controllers.Pca9685;
using RPi.Pwm;
using RPi.Pwm.Motors;

namespace RPi.ConsoleApp
{
    class Program
    {
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var options = new ConsoleOptions(args);

            var deviceFactory = new Pca9685DeviceFactory();
            var device = deviceFactory.GetDevice();
            var motorController = new PwmController(device);
            motorController.Init();
            
            switch (options.Mode)
            {
                case Mode.DcMotor: 
                    RunDcMotor(motorController);
                    break;

                case Mode.Servo: 
                    RunServo(motorController);
                    break;

                case Mode.Stepper:
                    motorController.StepperMotor.Rotate(600);
                    break;

                case Mode.Led:
                    RunLed(motorController);
                    break;

                case Mode.RawPwm:
                    RunRawPwm(device);
                    break;
            }

            motorController.AllStop();
            deviceFactory.Dispose();
        }

        private static void RunRawPwm(IPwmDevice pwmDevice)
        {
            while (!Console.KeyAvailable)
            {
                var channel = PwmChannel.C0;
                var pwmOn = 2000;
                var pwmOff = 2000;
                Log.Info(m => m("Set channel={0} to {1}", channel, pwmOn));
                pwmDevice.SetPwm(channel, 0, pwmOn);
                Thread.Sleep(1000);
                Log.Info(m => m("Set channel={0} to {1}", channel, pwmOff));
                pwmDevice.SetPwm(PwmChannel.C0, 0, pwmOff);
                Thread.Sleep(1000);
            }
        }

        private static void RunLed(PwmController motorController)
        {
            for (int i = 0; i < 20; i++)
            {
                motorController.Led0.On();
                Thread.Sleep(100);
                motorController.Led0.Off();
                Thread.Sleep(100);
            }

            for (int i = 0; i <= 100; i++)
            {
                motorController.Led0.On(i);
                Thread.Sleep(10);
            }
            for (int i = 100; i >= 0; i--)
            {
                motorController.Led0.On(i);
                Thread.Sleep(10);
            }
            motorController.Led0.Off();
        }

        private static void RunDcMotor(PwmController motorController)
        {
            for (int i = 10; i <= 100; i += 10)
            {
                motorController.DcMotor.Go(i);
                Thread.Sleep(1000);
            }

            motorController.DcMotor.Stop();
            Thread.Sleep(1000);

            for (int i = 10; i <= 100; i += 10)
            {
                motorController.DcMotor.Go(i, MotorDirection.Reverse);
                Thread.Sleep(1000);
            }

            motorController.DcMotor.Stop();
        }

        private static void RunServo(PwmController motorController)
        {
            motorController.Servo.MoveTo(0);
            Thread.Sleep(1000);

            motorController.Servo.MoveTo(100);
            Thread.Sleep(1000);

            motorController.Servo.MoveTo(50);
            Thread.Sleep(1000);
        }
    }
}
