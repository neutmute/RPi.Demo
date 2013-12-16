using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;

namespace RPi.Pwm
{
    class Program
    {
        private readonly static ILog Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var deviceFactory = new Pca9685DeviceFactory();
            var device = deviceFactory.GetDevice();
            var motorController = new PwmController(device);
            motorController.Init();

            //RunLed(motorController);


            motorController.StepperMotor.Rotate(600);

            //RunDcMotor(motorController);
            //RunServo(motorController);

            motorController.AllStop();
            deviceFactory.Dispose();

            //while (!Console.KeyAvailable)
            //{
            //    Log.Info("Set channel={0} to {1}", options.Channel, options.PwmOn);
            //    device.SetPwm(options.Channel, 0, options.PwmOn);
            //    Thread.Sleep(1000);
            //    Log.Info("Set channel={0} to {1}", options.Channel, options.PwmOff);
            //    device.SetPwm(options.Channel, 0, options.PwmOff);
            //    Thread.Sleep(1000);
            //}

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
                motorController.DcMotor.Go(i, Motors.MotorDirection.Reverse);
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
