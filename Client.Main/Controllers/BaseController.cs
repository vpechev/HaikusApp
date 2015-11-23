using Newtonsoft.Json;
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
    public class BaseController : Controller
    {
        protected const string uriFormatBase = @"http://localhost:8090/{0}";
        protected const string uriFormat = @"http://localhost:8090/{0}/{1}";
        protected const string uriFormatActionId = @"http://localhost:8090/{0}/{1}/{2}";
        private const string uriFormatAllPaging = "http://localhost:8090/{0}?skip={1}&take={2}";
        private const string uriFormatAllPagingAndSort = @"http://localhost:8090/{0}?skip={1}&take={2}&orderType={3}&sortingOrder={4}";

        
        protected async Task<T> GetByIdAsync<T>(string controllerName, long id) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var url = string.Format(uriFormat, controllerName, id);
                var result = await httpClient.GetStringAsync(url);
                
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        protected async Task<IEnumerable<T>> Get<T>(string controllerName, int skip, int take, int sortingValue = 0, int sortingOrder = 0) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format(uriFormatAllPagingAndSort, controllerName, skip, take, sortingValue, sortingOrder);
                return JsonConvert.DeserializeObject<IEnumerable<T>>(
                    await httpClient.GetStringAsync(url)
                );
            }
        }

        protected async Task<IEnumerable<T>> Get<T>(string controllerName, int skip, int take) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format(uriFormatAllPaging, controllerName, skip, take);
                //httpClient.DefaultRequestHeaders.Add("publishKey", "some admin key");
                return JsonConvert.DeserializeObject<IEnumerable<T>>(
                    await httpClient.GetStringAsync(url)
                );
            }
        }

        protected async Task<IEnumerable<T>> GetComplaints<T>(string controllerName, int skip, int take, string publishKey) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format(uriFormatAllPaging, controllerName, skip, take);
                if (publishKey != null)
                    httpClient.DefaultRequestHeaders.Add("publishKey", publishKey);
                
                return JsonConvert.DeserializeObject<IEnumerable<T>>(
                    await httpClient.GetStringAsync(url)
                );
            }
        }

        protected async Task Add<T>(string controllerName, string publishCode,T entity) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("publishKey", publishCode);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.PostAsJsonAsync(string.Format(uriFormatBase, controllerName), entity);
            }
        }

        protected async Task AddComplaint<T>(string controllerName, T entity) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.PostAsJsonAsync(string.Format(uriFormatBase, controllerName), entity);
            }
        }

        protected async Task Update<T>(string controllerName, string publishCode, T entity) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.PutAsJsonAsync(string.Format(uriFormat, controllerName), entity);
            }
        }

        protected async Task Delete<T>(string controllerName, string publishCode, long id) where T : class
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = string.Format(uriFormat, controllerName, id);
                httpClient.DefaultRequestHeaders.Add("publishKey", publishCode);
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await httpClient.DeleteAsync(uri);
            }
        }

    }
}
