using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<ActionResult> All(int skip, int take, int sortingValue = 0, int sortingOrder = 0)
        {
            ViewBag.Skip = skip;
            ViewBag.Take = take;
            ViewBag.SortingValue = sortingValue;
            ViewBag.SortingOrder = sortingOrder;

            var results = await base.Get<User>(ControllerName, skip, take, sortingValue, sortingOrder);
            if (sortingValue == 1)
            {
                if (sortingOrder == 0)
                {
                    var vips = results.Where(a => a.IsVip).ToList().OrderBy(a => a.ActualRating).ToList();
                    var novips = results.Where(a => !(a.IsVip)).ToList().OrderBy(a => a.ActualRating).ToList(); ;
                    results = vips.Concat(novips);
                }
                else
                {
                    var vips = results.Where(a => a.IsVip).ToList().OrderByDescending(a => a.ActualRating).ToList();
                    var novips = results.Where(a => !(a.IsVip)).ToList().OrderByDescending(a => a.ActualRating).ToList(); ;
                    results = vips.Concat(novips);
                }
            }

            return this.View(results);
        }

        public async Task<ActionResult> PromoteToVIP(long id, string publishKey)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("publishKey", "some admin key");
                await httpClient.PutAsJsonAsync( (string.Format(uriFormat + @"/vip", "users", id)), new Haiku());
            }
            return this.RedirectToAction("Details", "Users", new { id });
        }

        public async Task<ActionResult> Delete(int id, string publishCode)
        {
            await base.Delete<Haiku>("users", publishCode, id);
            return RedirectToAction("Index", "Haikus");
        }

    }
}
