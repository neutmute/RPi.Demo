using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Microsoft.AspNet.SignalR.Client;

namespace RPi.ConsoleApp.Comms
{
    class SignalRConnection
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private IHubProxy _piHubProxy;
        private HubConnection _hubConnection;
        private bool _connectionStable;
        private bool _killReceived;

        public async void Run()
        {
            await Start();

            await WaitForConnection();

            if (_hubConnection.State == ConnectionState.Connected)
            {
                Log.InfoFormat("Hello.???");
                _piHubProxy.Invoke("Hello");
            }
            else
            {
                Log.InfoFormat("No connection, no hello.");
            }

            Log.Info("Wait!");
            var t= WaitForKill();
            t.Wait();
        }

        public async Task WaitForConnection()
        {
            while (!_connectionStable)
            {
                Task.Delay(100);
            }
            Log.Info("Connection stable!");
        }

        public async Task WaitForKill()
        {
            Log.Info("Waiting for kill");
            while (!_killReceived)
            {
                Task.Delay(100);
            }
            Log.Info("Kill received!");
        }

        public async Task Start()
        {
            Log.Info("Connecting...");
            _hubConnection = new HubConnection("http://192.168.1.3:15794/");
            _hubConnection.TraceLevel = TraceLevels.All;
            _hubConnection.TraceWriter = Console.Out;

            _piHubProxy = _hubConnection.CreateHubProxy("PiHub");
            _piHubProxy.On("SetServo", (int percent) => Log.InfoFormat("SetServo({0})!", percent));

            _hubConnection.StateChanged += _hubConnection_StateChanged;
            _hubConnection.Start();
        }

        void _hubConnection_StateChanged(StateChange obj)
        {
            Log.InfoFormat("Connection={0}", _hubConnection.State);
            if (_hubConnection.State == ConnectionState.Connected || _hubConnection.State == ConnectionState.Disconnected)
            {
                _connectionStable = true;
            }
        }
    }
}
