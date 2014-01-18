using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Application.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        public ActionResult Search(string name = "*")
        {
            if (name == "*")
            {
                return RedirectToAction("Index", "Home");
            }
            name = Server.HtmlEncode(name);
            return Content(name);
        }

    }
}
