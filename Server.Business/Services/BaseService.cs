using Server.Business.DI;
using Server.Business.DI.Interfaces;
using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : IIdentifiable
    {
        
    }
}
