using Server.Business;
using Server.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace HaikusApp.Exceptions.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    { 
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                LogErrorWatcher.Error("Unauthorized", context.Exception);
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else if (context.Exception is MissingInputDataException)
            {
                LogErrorWatcher.Error("It's not passed input data", context.Exception);
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                LogErrorWatcher.Error("Internal Server Error", context.Exception);
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

    }
}