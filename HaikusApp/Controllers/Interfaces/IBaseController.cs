using Server.Data.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaikusApp.Controllers.Interfaces
{
    interface IBaseController<T> where T : Identifiable
    {
    }
}
