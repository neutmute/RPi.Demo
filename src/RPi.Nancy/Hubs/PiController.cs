using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Nancy.Helpers;
using RPi.Comms;
using RPi.Pwm;
using RPi.Pwm.Motors;

namespace RPi.NancyHost.Hubs
{
    public sealed class PiController
    {
        #region Singleton

        private PiController()
        {
            Log = LogManager.GetCurrentClassLogger();
        }

        public static PiController Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly PiController instance = new PiController();
        }

        #endregion

        #region Fields

        private readonly ILog Log;
        private Task _clawTask;
        #endregion


        #region Ctor

        public PwmController PwmController { get; set; }

        #endregion


        #region Methods

        public void SendCommand(PwmCommand pwmCommand)
        {
            PwmController.Command(pwmCommand);
        }

        public void Command(int channel, int dutyCyclePercent)
        {
            PwmController.Command(channel, dutyCyclePercent);
        }

        public void SendStepCommand(StepperCommand stepperCommand)
        {
            PwmController.Command(stepperCommand);
        }

        public void ActivateLaunchClaw()
        {
            if (_clawTask!= null && !_clawTask.IsCompleted)
            {
                Log.Info("Claw still running");
                return;
            }
            if (_clawTask != null)
            {
                _clawTask.Dispose();
            }
            _clawTask = GetClawTask();
            _clawTask.Start();
        }

        private Task GetClawTask()
        {
            var task = new Task(() =>
            {
                Log.Info("Claw!");

                var ingestCommand = new PwmCommand {Channel = DeviceChannel.Servo, DutyCyclePercent = 10};
                PwmController.Command(ingestCommand);

                Task.Delay(TimeSpan.FromMilliseconds(750)).Wait();

                var throwCommand = new PwmCommand {Channel = DeviceChannel.Servo, DutyCyclePercent = 70};
                PwmController.Command(throwCommand);
            });

            task.WhenCompleted(ClawCompleted, ClawCompleted);

            return task;
        }

        private void ClawCompleted(Task task)
        {
            if (task.IsFaulted)
            {
                Log.Error(task.Exception);
            }
        }

        #endregion

    }
}
