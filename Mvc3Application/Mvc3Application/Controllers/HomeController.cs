using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = string.Format("{0}/{1}/{2}",
              RouteData.Values["controller"],
              RouteData.Values["action"],
              RouteData.Values["id"]
              );

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
