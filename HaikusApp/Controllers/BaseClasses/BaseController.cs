using HaikusApp.Controllers.Interfaces;
using Server.Business.DI;
using Server.Business.DI.Interfaces;
using Server.Business.Managers;
using Server.Business.Services;
using Server.Data.Managers;
using Server.Data.Models.BaseClasses;
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
    public class BaseController<T> : ApiController /*IBaseController<T> */ where T : Identifiable
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
            return ServiceManager.GetServiceManager().CreateInstance<T>();
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