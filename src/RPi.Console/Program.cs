using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.AspNet.SignalR.Client;
using Raspberry.IO.Components.Controllers.Pca9685;
using RPi.ConsoleApp.Comms;
using RPi.ConsoleApp.IO;
using RPi.Pwm;
using RPi.Pwm.Motors;

namespace RPi.ConsoleApp
{
    
    /// <summary>
    /// USAGE example: 
    /// rpiconsole -a="17 Dec 2013 06:30"
    /// </summary>
    class Program
    {
        ILog Log;
      
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run(args);
        }

        private void Run(string[] args)
        {
            // Creating this from static causes an exception in Raspian. Not in ubunti though?
            Log  = LogManager.GetCurrentClassLogger();
            var options = new ConsoleOptions(args);

            if (options.ShowHelp)
            {
                Console.WriteLine("Options:");
                options.OptionSet.WriteOptionDescriptions(Console.Out);
                return;
            }

            var deviceFactory = new Pca9685DeviceFactory();
            var device = deviceFactory.GetDevice(options.UseFakeDevice);
            var motorController = new PwmController(device);
            motorController.Init();

            Log.InfoFormat("RPi.Console running with {0}", options);

            switch (options.Mode)
            {
                case Mode.DcMotor:
                    RunDcMotor(motorController);
                    break;

                case Mode.Servo:
                    RunServo(motorController);
                    break;

                case Mode.Stepper:
                    motorController.Stepper.Rotate(600);
                    break;

                case Mode.Led:
                    RunLed(motorController);
                    break;

                case Mode.RawPwm:
                    RunRawPwm(device);
                    break;

                case Mode.AlarmClock:
                    var alarmClock = new AlarmClock(motorController);
                    alarmClock.Set(options.AlarmDate);
                    alarmClock.WaitForAlarm();
                    break;

                case Mode.SignalRTest:
                    var signalRConnection = new SignalRConnection(motorController);
                    signalRConnection.Run();
                    break;

                case Mode.SoundTest:
                    var soundTest = new SoundTest();
                    Log.Info("Aplay...");
                    soundTest.PlayWithAPlay();
                    
                    soundTest.PlayWithSoundPlayer();
                    soundTest.PlayWithSoundPlayerAsync();
                    break;
            }

            motorController.AllStop();
            deviceFactory.Dispose();

            //http://nlog-project.org/2011/10/30/using-nlog-with-mono.html
           // NLog.LogManager.Configuration = null;
        }

        private void RunRawPwm(IPwmDevice pwmDevice)
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
