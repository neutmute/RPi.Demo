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
using RPi.NancyHost.Hubs;
using RPi.Pwm;

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

            var options = GetStartOptions();
            PiController.Instance.PwmController = GetPwmController();

            Log.InfoFormat("rpi.nancy starting {0} at {1}...", options.ServerFactory, options.Urls[0]);

            using (WebApp.Start<Startup>(options))
            {
                Log.Info("...server started and listening");


                Console.Write("Press any key to halt server");
                Console.ReadKey();
                Log.Info("server stopping...");
            }
        }

        private static PwmController GetPwmController()
        {
            var deviceFactory = new Pca9685DeviceFactory();
            var device = deviceFactory.GetDevice();
            var motorController = new PwmController(device);
            motorController.Init();
            return motorController;
        }

        private static StartOptions GetStartOptions()
        {
            var options = new StartOptions
            {
                //ServerFactory = "Microsoft.Owin.Host.HttpListener"
                ServerFactory = "Nowin"
            };

            string url;
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                url = "http://192.168.1.64:8080"; // pi/mono doesn't like the wildcard ip
            }
            else
            {
                url = "http://*:8080";
            }

            options.Urls.Add(url);
            return options;
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
