using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using RPi.Comms;

namespace RPi.NancyHost.Hubs
{
    class PiController
    {
        private ILog Log;
        private readonly static Lazy<PiController> _instance = new Lazy<PiController>(() => new PiController());

        private PiController()
        {
            Log = LogManager.GetCurrentClassLogger();
        }

        public static PiController Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public void SendCommand(RpiCommand command)
        {
            Log.InfoFormat("Command received: {0}", command);
        }
    }
}
