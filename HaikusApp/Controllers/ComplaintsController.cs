using HaikusApp.Controllers.BaseClasses;
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
    public class ComplaintsController : BaseController<Complaint>
    {
        [HttpPost]
        public Complaint Post([FromBody] Complaint entity)
        {
            IBaseService<Complaint> service = ServiceManager.GetServiceManager().CreateInstance<Complaint>();
            return ((ComplaintService)service).Add(entity);
        }

        public Complaint Get()
        {
            return null;
        }

        [HttpGet]
        public IList<Complaint> Get(int skip,int take)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Complaint> service = ServiceManager.GetServiceManager().CreateInstance<Complaint>();
            return ((ComplaintService)service).Get(skip, take, publishCode);
        }
    }
}