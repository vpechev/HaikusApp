using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions.Filters;
using Server.Business.DI.Interfaces;
using Server.Business.Managers;
using Server.Business.Services;
using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HaikusApp.Controllers
{
    [RoutePrefix("complaints")]
    [CustomExceptionFilter]
    public class ComplaintsController : BaseController<Complaint>
    {
        public Complaint Post(Complaint entity)
        {
            IBaseService<Complaint> service = ServiceManager.GetServiceManager().CreateInstance<Complaint>();
            return ((ComplaintService)service).Add(entity);
        }

        [HttpGet]
        public IList<Complaint> Get([FromUri]int skip, [FromUri]int take)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Complaint> service = ServiceManager.GetServiceManager().CreateInstance<Complaint>();
            return ((ComplaintService)service).Get(skip, take, publishCode);
        }
    }
}