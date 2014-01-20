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

            var options = new StartOptions
            {
                //ServerFactory = "Microsoft.Owin.Host.HttpListener"
                ServerFactory = "Nowin"
            };

            //var url = "http://*:8080"; // windows
            var url = "http://192.168.1.64:8080"; // pi/mono

            options.Urls.Add(url);

            Log.InfoFormat("rpi.nancy starting on {0}...", url);

            using (WebApp.Start<Startup>(options))
            {
                Log.Info("...server started and listening");


                Console.Write("Press any key to halt server");
                Console.ReadKey();
                Log.Info("server stopping...");
            }
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseNancy();
        }
    }

}
