using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HaikusApp.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.FirstOrDefault(a => a.Key == "publishKey");
            //if (String.IsNullOrEmpty(token))
            //{
            //    throw new UnauthorizedAccessException();
            //}
        }
    }
}