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
    }
}