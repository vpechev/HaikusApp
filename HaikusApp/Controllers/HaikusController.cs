using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions.Filters;
using Server.Business.DAOs;
using Server.Business.DI.Interfaces;
using Server.Business.Managers;
using Server.Business.Services;
using Server.Data.Enums;
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
        [HttpPost]
        public Haiku Post(Haiku entity)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            return ((HaikuService)service).Add(entity, publishCode);
        }

        [HttpPost]
        [Route("/{id}/ratings")]
        public HaikuDAO PostRating(long id, [FromBody]int ratingValue)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).RateHaiku(id, ratingValue);
            return ((HaikuService)service).RateHaiku(id, ratingValue);
        }

        [HttpGet]
        public IList<HaikuDAO> Get([FromUri]int skip, int take, string orderType, SortingOrder sortingOrder)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            return ((HaikuService)service).Get(skip, take, orderType, sortingOrder);
        }

        [HttpPut]
        public void Put(Haiku entity)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).Update(entity, publishCode);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).Remove(id, publishCode);
        }

        [HttpDelete]
        [Route("/All")]
        public void DeleteAll()
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).DeleteAllHaikusPerUser(publishCode);
        }
    }
}
