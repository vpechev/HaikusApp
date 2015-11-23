using Client.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<ActionResult> Index()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return await All(0, 10, 0, 0);

        }

        public ActionResult RedirectToAddHaiku()
        {
            return this.View("Add");
        }

        public async Task<ActionResult> Add(AddHaiku haiku)
        {
             await base.Add<Haiku>(ControllerName, haiku.PublishCode, new Haiku(){ Text = haiku.Text } );
             return RedirectToAction("Index", "Haikus");
        }
        
        public async Task<ActionResult> Details(long id)
        {
            return this.View(await base.GetByIdAsync<Haiku>(ControllerName, id));
        }

        public async Task<ActionResult> All(int skip, int take, int sortingValue=0, int sortingOrder = 0)
        {
            ViewBag.Skip = skip;
            ViewBag.Take = take;
            ViewBag.SortingValue = sortingValue;
            ViewBag.SortingOrder = sortingOrder;
            
            var result = await base.Get<Haiku>(ControllerName, skip, take, sortingValue, sortingOrder);
            if(sortingValue == 1){
                if(sortingOrder == 0)
                    result = result.OrderBy(x=>x.ActualRating);
                else
                    result = result.OrderByDescending(x=>x.ActualRating);
            }

            return this.View("index", result);
        }


        public async Task<ActionResult> UpdateForm(int id, string publishCode)
        {
            Haiku h = await base.GetByIdAsync<Haiku>(ControllerName, id);
            h.PublishCode = publishCode;
            return this.View("UpdateForm", h);            
        }

        public async Task<ActionResult> Update(int id, string publishCode, Haiku entity)
        {
            entity.Date = DateTime.Now;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("publishKey", publishCode);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.PutAsJsonAsync(string.Format(uriFormatBase, ControllerName), entity);
                return this.RedirectToAction("Details", ControllerName, new { entity.Id });
            }
        }

        public async Task<ActionResult> Delete(int id, string publishCode)
        {
            await base.Delete<Haiku>("haikus", publishCode, id);
            return RedirectToAction("Index", "Haikus");
        }

        public async Task<ActionResult> DeleteAllHaikus(string publishKey)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormatBase + "/all", ControllerName);
                httpClient.DefaultRequestHeaders.Add("publishKey", publishKey);
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.DeleteAsync(uri);
            }

            return RedirectToAction("Index", "Haikus");
        }
        

        public async Task<ActionResult> Complaints(int id)
        {
            Complaint c = new Complaint(){
                HaikuId = id,
                Date = DateTime.Now
            };

            await base.AddComplaint<Complaint>("complaints", c);
            return RedirectToAction("Index", "Haikus");
        }

        public async Task<ActionResult> Rating(int id, int rating) {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.PostAsJsonAsync(string.Format("http://localhost:8090/{0}/{1}/ratings", ControllerName, id), rating);
            }
            return this.RedirectToAction("Details", "Haikus", new { id });
        }


    }
}
 