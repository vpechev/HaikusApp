using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class HaikusController : BaseController
    {
        private const string ControllerName = "haikus";
        //
        // GET: /Haikus/

        public async Task<ActionResult> Details(long id)
        {
            return this.View(await base.GetByIdAsync<Haiku>(ControllerName, id));
        }

        public async Task<ActionResult> All(int skip, int take, string sortingValue, int sortingOrder)
        {
            return this.View(await base.Get<Haiku>(ControllerName, skip, take, sortingValue, sortingOrder));
        }

        public async Task Complaints(int id, string publishCode)
        {
            Complaint c = new Complaint(){
                HaikuId = id
            };

            await base.Add<Complaint>("complaints", publishCode, c);
        }

    }
}
 