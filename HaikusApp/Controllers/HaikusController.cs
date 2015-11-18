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
    [RoutePrefix("Haikus")]
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
        [Route("{id}/ratings")]
        public HaikuDAO PostRating(long id, [FromBody]int ratingValue)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).RateHaiku(id, ratingValue);
            return ((HaikuService)service).RateHaiku(id, ratingValue);
        }

        [HttpGet]
        [Route("All")]
        public IList<HaikuDAO> Get([FromUri]int skip, int take, string orderType, SortingOrder sortingOrder)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            return ((HaikuService)service).Get(skip, take, orderType, sortingOrder);
        }

        [HttpGet]
        [Route("{id}")]
        public HaikuDAO Get([FromUri]long id)
        {
            IBaseService<Haiku> service = GetService();
            return ((HaikuService)service).Get(id);
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
        [Route("All")]
        public void DeleteAll()
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).DeleteAllHaikusPerUser(publishCode);
        }
    }
}
