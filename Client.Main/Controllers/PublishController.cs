using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class PublishController : BaseController
    {
        //
        // GET: /Publish/

        public ActionResult Validate(string controllerName, string actionName, long id = 0)
        {
            var model = new PublishModel(controllerName, actionName, id);
            return PartialView(model);
        }

        // POST: /Publish
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validate(PublishModel model)
        {
            if (model.EntityId != 0) 
            {
                return this.RedirectToAction(model.ActionName, model.ControllerName, new { id=model.EntityId, publishCode = model.Code });
            }

            return this.RedirectToAction(model.ActionName, model.ControllerName, new { publishCode = model.Code });
        }

    }
}
