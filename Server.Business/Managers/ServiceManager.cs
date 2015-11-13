using Microsoft.Practices.Unity;
using Server.Business.DI;
using Server.Business.Services;
using Server.Data.Managers;
using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Managers
{
    public class ServiceManager
    {
        private static ServiceManager _serviceManager;
        private ServiceManager() { }

        public BaseService<T> CreateInstance<T>() where T : IIdentifiable
        {
            return ServiceObjectContainer.DefaultContainer.Resolve<BaseService<T>>();
        }

        public BaseService<T> CreateInstance<T>(string publishCode) where T : IIdentifiable
        {
            return ServiceObjectContainer.DefaultContainer.Resolve<BaseService<T>>(new ParameterOverride("publishcode", publishCode));
        }

        public static ServiceManager GetServiceManager(IUnityContainer container = null)
        {
            if (_serviceManager == null)
            {
                _serviceManager = new ServiceManager();
            }

            if (container != null)
            {
                ServiceObjectContainer.DefaultContainer = container;
            }
            return _serviceManager;
        }
    }
}
