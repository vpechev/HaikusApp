using HaikusApp.Controllers.Interfaces;
using Server.Data.Models.Interfaces;
using Server.Data.Repositories.Interfaces;
using Server.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Server.Data.Managers;

namespace HaikusApp.Controllers.BaseClasses
{
    public class BaseController<T> : ApiController, IBaseController where T : IIdentifiable
    {
        #region Delegates
        //private Func<HttpRequestMessage> _getRequest;
        private Func<long> _gettingUserId;
        #endregion

        #region Constructors
        public BaseController() { }

        public BaseController(Func<HttpRequestMessage> requestDelegate)
            : this()
        {
            //GetRequest = requestDelegate;
        }
        #endregion
        //public Func<HttpRequestMessage> GetRequest
        //{
        //    get { return _getRequest; }
        //    private set { _getRequest = value; }
        //}

        public IList<T> Get()
        {
            IBaseRepository<T> repo = this.GetRepository();
            //IList<T> results = repo.Get();
            //return results;
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            IBaseRepository<T> repo = this.GetRepository();
            //return repo.Get(id);
            throw new NotImplementedException();
        }

        public T Post(T entity)
        {
            IBaseRepository<T> repo = this.GetRepository();
            return repo.Add(entity);
        }

        public IHttpActionResult Delete(long id)
        {
            IBaseRepository<T> repo = this.GetRepository();
            repo.Remove(id);
            return Ok();
        }

        public T Put(T entity)
        {
            IBaseRepository<T> repo = this.GetRepository();
            return repo.Update(entity);
        }

        private long GetUserId()
        {
            long res;
            bool isSet = Int64.TryParse(this.Request.Headers.GetValues("userId").FirstOrDefault(), out res);
            if (isSet)
                return res;
            throw new UnauthorizedAccessException();
        }

        protected IBaseRepository<T> GetRepository()
        {
            long userId = this.GettingUserId();
            //return DataManager.CreateInstance<IBaseRepository<T>>(userId);
            return null;
        }

        public Func<long> GettingUserId
        {
            get
            {
                if (_gettingUserId == null)
                    _gettingUserId = () => GetUserId();
                return _gettingUserId;
            }
            set { _gettingUserId = value; }
        }

    }
}