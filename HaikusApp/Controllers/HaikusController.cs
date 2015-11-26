using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions.Filters;
using HaikusApp.Filters;
using Server.Business.DAOs;
using Server.Business.DI.Interfaces;
using Server.Business.Enums;
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
        [AuthFilter]
        public Haiku Post(Haiku entity)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            return ((HaikuService)service).Add(entity, base.GettingPublishCode());
        }

        [HttpPost]
        [Route("{id}/ratings")]
        public HaikuDTO PostRating([FromUri]long id, [FromBody]int ratingValue)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).RateHaiku(id, ratingValue);
            return ((HaikuService)service).RateHaiku(id, ratingValue);
        }

        [HttpGet]
        public IList<HaikuDTO> Get([FromUri]int skip, [FromUri]int take, [FromUri]HaikuSortBy orderType, [FromUri]SortingOrder sortingOrder)
        {
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            return ((HaikuService)service).Get(skip, take, orderType, sortingOrder);
        }

        [HttpGet]
        [Route("{id}")]
        public HaikuDTO Get([FromUri]long id)
        {
            IBaseService<Haiku> service = GetService();
            return ((HaikuService)service).Get(id);
        }

        [HttpPut]
        public void Put([FromBody]Haiku entity)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<Haiku> service = ServiceManager.GetServiceManager().CreateInstance<Haiku>();
            ((HaikuService)service).Update(entity, publishCode);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromUri]long id)
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
