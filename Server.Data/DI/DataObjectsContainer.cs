using Microsoft.Practices.Unity;
using Server.Data.Models;
using Server.Data.Repositories;
using Server.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.DI
{
    public static class DataObjectsContainer
    {
        private static IUnityContainer defaultContainer;
        public static IUnityContainer DefaultContainer
        {
            get
            {
                if (defaultContainer == null)
                {
                    // Container initialization by code
                    defaultContainer = new UnityContainer();
                    defaultContainer.RegisterTypes(
                        AllClasses.FromLoadedAssemblies(),
                        WithMappings.FromMatchingInterface,
                        WithName.Default);

                    defaultContainer.RegisterType<IBaseRepository<Haiku>, HaikuRepository>();
                    defaultContainer.RegisterType<IBaseRepository<User>, UserRepository>();
                }
                return defaultContainer;
            }
            set
            {
                if (value != null)
                    defaultContainer = value;
                else
                    throw new ArgumentException("the default container is null");
            }
        }
    }
}
