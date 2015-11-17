using Server.Data.Enums;
using Server.Data.Models.BaseClasses;
using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Identifiable
    {
        T Get (long id);

        IList<T> Get (int offsetCount, int entitiesCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC);

        T Add (T entity, long userId = 0);

        T Update(T entity, long userId = 0);

        void Remove (long id);

        string SelectAllQuery { get; }
        string SelectByIdQuery { get; }
        string InsertQuery { get; }
        string UpdateByIdQuery { get; }
        string DeleteByIdQuery { get; }
    }
}
