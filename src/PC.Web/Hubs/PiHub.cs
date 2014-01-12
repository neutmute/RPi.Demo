using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using NLog;

namespace PC.Web
{
    public class PiHub : Hub
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public void Hello()
        {
            Log.Info("Hello received!");
        }

        public override Task OnConnected()
        {
            Log.Info("PiHub connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }
    }
}