using Server.Data.Models.BaseClasses;
using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Business.DI.Interfaces
{
    public interface IBaseService<T> where T : Identifiable
    {
        //T Get(long id);

        long GetUserIdByPublishCode(string code);

        bool IsAdminPublishCode(string code);
    }
}
