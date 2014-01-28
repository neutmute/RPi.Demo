using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using NLog;
using RPi.Comms;
using RPi.NancyHost.Hubs;

namespace PC.Web.Hubs
{
    public class RemoteHubBase : Hub
    {
        private static readonly Logger _Log = LogManager.GetCurrentClassLogger();

        protected Logger Log { get { return _Log; } }

        public override Task OnConnected()
        {
            Log.Info("RemoteHub connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public void Ping()
        {
            Log.Info("Remote sent a ping");
        }
    }

    /// <summary>
    /// Methods the browser can call
    /// </summary>
    public class RemoteHub : RemoteHubBase
    {
        /// <summary>
        /// Try to reduce data conversions to see if it helps perf. didn't really.
        /// </summary>
        public void SetServo(int value)
        {
            PiController.Instance.Command(2, value);
        }

        public void SetPwm(DeviceChannel channel, int value)
        {
            Log.Debug("SetPwm({0},{1})", channel, value);
            var piCommand = new PwmCommand(channel, value);
            PiController.Instance.SendCommand(piCommand);
        }

        public void RunStepper(int steps, int delayMs)
        {
            Log.Debug("RunStepper({0},{1})", steps, delayMs);
            var stepperCommand = new StepperCommand(steps, delayMs);
            PiController.Instance.SendStepCommand(stepperCommand);
        }
    }
}