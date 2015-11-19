using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Client.Main.Models;
using Newtonsoft.Json;

namespace Client.Main.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return null;
            
        }

        public async Task<ActionResult> Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            //return this.View(await this.GetHaikuByIdAsync(11));
            return null;
        }


        
    }
}