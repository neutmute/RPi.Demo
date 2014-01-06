using Microsoft.Owin;
using Owin;

namespace PC.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
