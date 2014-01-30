using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using NLog;
using PC.Web.Hubs;
using RPi.Comms;

namespace RPi.NancyHost.Hubs
{

    public class LauncherHub : RemoteHubBase
    {
        public override Task OnConnected()
        {
            Log.Info("LauncherHub connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }
        
        public void Fire()
        {
            PiController.Instance.ActivateLaunchClaw();
        }

        public void SetMotor(int value)
        {
            var channel = DeviceChannel.DcMotor;
            Log.Info("SetPwm({0},{1})", channel, value);
            var piCommand = new PwmCommand(channel, value);
            PiController.Instance.SendCommand(piCommand);
        }

        public void RotateTurret(int steps)
        {
            const int delayMs = 5;
            Log.Info("RunStepper({0},{1})", steps, delayMs);
            var stepperCommand = new StepperCommand(steps, delayMs);
            PiController.Instance.SendStepCommand(stepperCommand);
        }
    }
}
