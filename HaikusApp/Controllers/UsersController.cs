﻿using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions;
using HaikusApp.Exceptions.Filters;
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
    [RoutePrefix("users")]
    public class UsersController : BaseController<User>
    {
        [HttpPost]
        public User Post(User entity)
        {
            IBaseService<User> service = ServiceManager.GetServiceManager().CreateInstance<User>();
            return ((UserService)service).Add(entity);
        }

        [HttpPut]
        [Route("{id}/vip")]
        public void Put([FromUri]long id)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<User> service = ServiceManager.GetServiceManager().CreateInstance<User>();
            ((UserService)service).PromoteToVip(publishCode, id);
        }

        [HttpGet]
        public IList<UserDTO> Get([FromUri] int skip, [FromUri]int take, UserSortBy orderType, SortingOrder sortingOrder = SortingOrder.ASC)
        {
            IBaseService<User> service = ServiceManager.GetServiceManager().CreateInstance<User>();
            return UserDTO.CovertToUserDTO(((UserService)service).Get(skip, take, orderType, sortingOrder));
        }

        [HttpGet]
        public FullUserDTO Get([FromUri]long id)
        {
            IBaseService<User> service = base.GetService();
            var user= ((UserService)service).Get(id);;
            return user;
        }

        [HttpDelete]
        public void Delete([FromUri]long id)
        {
            var publishCode = base.GettingPublishCode();
            IBaseService<User> service = ServiceManager.GetServiceManager().CreateInstance<User>();
            ((UserService)service).RemoveUserWithHaikus(publishCode, id);
        }
    }
}
