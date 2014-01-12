using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace PC.Web.Hubs
{
    public class RemoteHubController
    {
        private readonly static Lazy<RemoteHubController> _instance = new Lazy<RemoteHubController>(() => new RemoteHubController(GlobalHost.ConnectionManager.GetHubContext<RemoteHub>().Clients));

        private RemoteHubController(IHubConnectionContext clients)
        {
            Clients = clients;
        }

        public static RemoteHubController Instance
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

        //public void SendCommand(RpiCommand command)
        //{
        //    Clients.All.SendCommand(command);
        //}
    }
}