using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.AspNet.SignalR.Client;

namespace RPi.ConsoleApp.Comms
{
    class SignalRConnection
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public async void Run()
        {
            await Start();
        }

        public async Task Start()
        {
            Log.Info("Connecting...");
            var hubConnection = new HubConnection("http://localhost:15794/");
            IHubProxy piHubProxy = hubConnection.CreateHubProxy("PiHub");
            piHubProxy.On("Ping", () => Log.Info("Ping!"));
            piHubProxy.On("SetServo", (int percent) => Log.Info("SetServo!"));
           
            Log.Info("Started!");
            hubConnection.Start();
        }
    }
}
