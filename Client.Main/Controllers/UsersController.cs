using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class UsersController : BaseController
    {
        private const string ControllerName = "users";
        //
        // GET: /Haikus/

        public async Task<ActionResult> Details(long id)
        {
            return this.View(await base.GetByIdAsync<User>(ControllerName, id));
        }

        public async Task<ActionResult> All(int skip, int take, string sortingValue, int sortingOrder)
        {
            return this.View(await base.Get<User>(ControllerName, skip, take, sortingValue, sortingOrder));
        }


    }
}
