using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Main.Controllers
{
    public class BaseController : Controller
    {
        private static readonly string uriFormatBase = @"http://localhost:8090/{0}";
        private static readonly string uriFormat = @"http://localhost:8090/{0}/{1}";
        
        protected async Task<T> GetByIdAsync<T>(string controllerName, long id) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(string.Format(uriFormat, controllerName, id));
                
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        protected async Task<IEnumerable<T>> Get<T>(string controllerName, int skip, int take, string sortingValue, int sortingOrder) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(
                    await httpClient.GetStringAsync(string.Format(uriFormat, controllerName, skip, take, sortingValue, sortingOrder))
                );
            }
        }

        protected async Task Add<T>(string controllerName, string publishCode,T entity) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("publishcode", publishCode);
                await httpClient.PostAsJsonAsync(string.Format(uriFormatBase, controllerName), entity);
            }
        }

        protected async Task Update<T>(string controllerName, string publishCode, T entity) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("publishcode", publishCode);
                await httpClient.PutAsJsonAsync(string.Format(uriFormat, controllerName), entity);
            }
        }

        protected async Task Delete<T>(string controllerName, string publishCode, long id) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("publishcode", publishCode);
                await httpClient.DeleteAsync(string.Format(uriFormat, controllerName, id));
            }
        }

    }
}
