using HaikusApp.Controllers.BaseClasses;
using HaikusApp.Exceptions;
using HaikusApp.Exceptions.Filters;
using Server.Data.Models;
using Server.Data.Repositories;
using Server.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HaikusApp.Controllers
{
    [CustomExceptionFilter]
    public class UsersController : BaseController<User>
    {
        public User Post(User entity)
        {
            IBaseRepository<User> repo = new UserRepository();
            return null;
        }
    }
}
