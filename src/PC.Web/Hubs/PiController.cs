using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RPi.Comms;

namespace PC.Web
{
    public class PiController
    {
        private readonly static Lazy<PiController> _instance = new Lazy<PiController>(() => new PiController(GlobalHost.ConnectionManager.GetHubContext<PiHub>().Clients));

        private PiController(IHubConnectionContext clients)
        {
            Clients = clients;
        }

        public static PiController Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext Clients
        {
            get;
            set;
        }

        public void SendCommand(RpiCommand command)
        {
            Clients.All.SendCommand(command);
        }
    }
}