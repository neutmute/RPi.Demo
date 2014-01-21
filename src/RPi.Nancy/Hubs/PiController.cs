using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
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



        private ILog Log;

        public PwmController PwmController { get; set; }
        
        public void SendCommand(PwmCommand pwmCommand)
        {
            PwmController.Command(pwmCommand);
        }


        public void SendStepCommand(StepperCommand stepperCommand)
        {
            PwmController.Command(stepperCommand);
        }
    }
}
