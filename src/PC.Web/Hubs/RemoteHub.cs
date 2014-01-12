using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using NLog;
using RPi.Comms;

namespace PC.Web.Hubs
{
   

    public class RemoteHub : Hub
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        

        public override Task OnConnected()
        {
            Log.Info("RemoteHub connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public void Ping()
        {
            Log.Info("Remote sent a ping");
        }

        public void SetPwm(PwmChannel channel, int value)
        {
            Log.Info("SetPwm({0},{1})", channel, value);
            var piCommand = new RpiCommand();
            piCommand.PwmCommands.Add(new PwmCommand(channel, value));
            PiController.Instance.SendCommand(piCommand);
        }
    }
}