using HaikusApp.Controllers.Interfaces;
using Server.Business.DI;
using Server.Business.DI.Interfaces;
using Server.Business.Managers;
using Server.Data.Models.Interfaces;
using Server.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HaikusApp.Controllers.BaseClasses
{
    public class BaseController<T> : ApiController, IBaseController where T : IIdentifiable
    {
        #region Delegates
        //private Func<HttpRequestMessage> _getRequest;
        private Func<string> _gettingPublishCode;
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

        //public IList<T> Get()
        //{
        //    IBaseService<T> service = this.GetService();
        //    //IList<T> results = repo.Get();
        //    //return results;
        //    throw new NotImplementedException();
        //}

        //public T Get(long id)
        //{
        //    IBaseService<T> service = this.GetService();
        //    //return repo.Get(id);
        //    throw new NotImplementedException();
        //}

        //public virtual T Post(T entity)
        //{
        //    IBaseService<T> service = this.GetServiceWithPublishCode();
        //    return service.Add(entity);
        //}

        //public IHttpActionResult Delete(long id)
        //{
        //    IBaseService<T> service = this.GetServiceWithPublishCode();
        //    service.Remove(id);
        //    return Ok();
        //}

        //public T Put(T entity)
        //{
        //    IBaseService<T> repo = this.GetServiceWithPublishCode();
        //    return repo.Update(entity);
        //}

        private string GetPasswordCode()
        {
            string res = this.Request.Headers.GetValues("publishKey").FirstOrDefault();
            if (res != null)
                return res;
            throw new UnauthorizedAccessException();
        }

        protected IBaseService<T> GetService()
        {
            return ServiceManager.GetServiceManager().CreateInstance<T>();
        }

        protected IBaseService<T> GetServiceWithPublishCode()
        {
            string publishCode = this.GettingPublishCode();
            return ServiceManager.GetServiceManager().CreateInstance<T>(publishCode);
        }

        public Func<string> GettingPublishCode
        {
            get
            {
                if (_gettingPublishCode == null)
                    _gettingPublishCode = () => GetPasswordCode();
                return _gettingPublishCode;
            }
            set { _gettingPublishCode = value; }
        }

    }
}