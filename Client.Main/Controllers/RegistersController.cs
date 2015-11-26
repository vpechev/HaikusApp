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
    public class RegistersController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Index(User entity)
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
            return View();
            
        }

     



    }
}