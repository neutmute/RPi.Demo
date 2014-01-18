using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;
using Common.Logging;

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

            var url = "http://localhost:1234";
            Log.InfoFormat("rpi.nancy starting on {0}", url);
            using (var host = new Nancy.Hosting.Self.NancyHost(new Uri(url)))
            {
                host.Start();
                Console.ReadKey();
            }
        }
    }
}
