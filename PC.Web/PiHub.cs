using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using NLog;

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

        public void SetServo(int percent)
        {
            Clients.All.SetServo(percent);
        }

        public void Ping()
        {
            Clients.All.Ping();
        }
    }


    public class PiHub : Hub
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public void Hello()
        {
            Log.Info("Hello received");
            //PiController.Instance.SetServo(90);
        }

        public override Task OnConnected()
        {
            Log.Info("Connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }
    }
}