using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using NLog;

namespace PC.Web.Controllers
{
    public class PwmController : Controller
    {

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ping()
        {
            PiController.Instance.Ping();
            return RedirectToAction("Index");
        }

        public ActionResult Servo(int percent)
        {
            PiController.Instance.SetServo(percent);
            return RedirectToAction("Index");
        }

    }
}
