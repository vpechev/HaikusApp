using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions.Filters;
using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HaikusApp.Controllers
{
    [CustomExceptionFilter]
    public class HaikusController : BaseController<Haiku>
    {

    }
}
