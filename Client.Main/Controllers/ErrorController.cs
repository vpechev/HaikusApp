using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(int? id)
        {
            return View();
        }

        public ActionResult Error(string message)
        {
            if (String.IsNullOrEmpty(message))
                return View();
            return View("Error", message);
        }
    }
}