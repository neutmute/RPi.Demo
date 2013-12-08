using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPi.Slides.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [HttpPost]
        public ActionResult DivideByZero()
        {
            var i = 0;
            var j = 5/i;
            return View("Index");
        }
    }
}
