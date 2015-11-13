using Microsoft.Practices.Unity;
using Server.Business.DI.Interfaces;
using Server.Business.Services;
using Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DI
{
    public class ServiceObjectContainer
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

                    defaultContainer.RegisterType<IBaseService<Haiku>, HaikuService>();
                    defaultContainer.RegisterType<IBaseService<User>, UserService>();
                    defaultContainer.RegisterType<IBaseService<Complaint>, ComplaintService>();
                }
                return defaultContainer;
            }
            set
            {
                if (value != null)
                    defaultContainer = value;
                else
                    throw new ArgumentException("service default container is null");
            }
        }
    }
}
