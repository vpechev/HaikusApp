using Microsoft.Practices.Unity;
using Server.Data.DI;
using Server.Data.Models.Interfaces;
using Server.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Managers
{
    public class DataManager
    {
        private static DataManager _dataManager;
        private DataManager() { }

        public IBaseRepository<T> CreateInstance<T>(long userId) where T : IIdentifiable
        {
            return DataObjectsContainer.DefaultContainer.Resolve<IBaseRepository<T>>(new ParameterOverride("userId", userId));
        }

        public static DataManager GetDataManager(IUnityContainer container = null)
        {
            if (_dataManager == null)
            {
                _dataManager = new DataManager();
            }

            if (container != null)
            {
                DataObjectsContainer.DefaultContainer = container;
            }
            return _dataManager;
        }
    }
}
