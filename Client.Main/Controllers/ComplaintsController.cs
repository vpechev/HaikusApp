using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class ComplaintsController : BaseController
    {
        private const string ControllerName = "complaints";
        //
        // GET: /Complaints/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public async Task<ActionResult> All(int skip, int take, string publishKey)
        {
            try
            {
                ViewBag.Skip = skip;
                ViewBag.Take = take;

                return this.View("index", await base.GetComplaints<Complaint>(ControllerName, skip, take, publishKey));
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Error", "Error", new { msg = "No access to this resource." });
            }
        }

    }
}
