using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace RPi.NancyHost
{
    public class PiRemoteModule : NancyModule
    {
        public PiRemoteModule()
        {
            Get["/"] = parameters => View["index.html"];
            Get["/launcher/"] = parameters => View["launcher.html"];
        }
    }
}
