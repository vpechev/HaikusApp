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
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View("_Register");
        }
        
        [HttpPost]
        public async Task<ActionResult> Register(User entity)
        {
            if (String.IsNullOrEmpty(entity.Username) || String.IsNullOrEmpty(entity.PublishCode))
            {
                return null;
            }
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = string.Format(BaseController.uriFormatBase, "Users");
                await httpClient.PostAsJsonAsync(uri, entity);
            }
            return RedirectToAction("All", "Haikus");
        }


        
    }
}