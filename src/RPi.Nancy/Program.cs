using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Nancy.Hosting.Self;
using Common.Logging;
using Owin;
using Nancy;

namespace RPi.NancyHost
{
    class Program
    {
        ILog Log;
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            Log = LogManager.GetCurrentClassLogger();

            var webUrl = "http://localhost:1234";
            var signalRurl = "http://localhost:1235";
            
            Log.InfoFormat("rpi.nancy starting on {0}", webUrl);

            //using (var webHost = new Nancy.Hosting.Self.NancyHost(new Uri(webUrl)))
            //{
                using (WebApp.Start<Startup>(signalRurl))
                {
                    //webHost.Start();
                    Console.Write("Press any key");
                    Console.ReadKey();
                    //webHost.Stop();
                }
            //}
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  app.MapSignalR();
            app.UseNancy();
        }
    }

}
