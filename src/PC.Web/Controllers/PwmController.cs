using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using NLog;
using RPi.Comms;

namespace PC.Web.Controllers
{
    public class PwmController : Controller
    {

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Servo(int percent)
        {
            PiController.Instance.SendCommand(new RpiCommand{Servo = new PwmCommand(percent)});
            return RedirectToAction("Index");
        }

        public ActionResult DcMotor(int percent)
        {
            PiController.Instance.SendCommand(new RpiCommand { DcMotor = new PwmCommand(percent) });
            return RedirectToAction("Index");
        }

        public ActionResult Led(int percent)
        {
            PiController.Instance.SendCommand(new RpiCommand { Led = new PwmCommand(percent) });
            return RedirectToAction("Index");
        }

        public ActionResult Stepper(int steps, int delayMs)
        {
            PiController.Instance.SendCommand(new RpiCommand { Stepper = new StepperCommand(steps, delayMs) });
            return RedirectToAction("Index");
        }
    }
}
