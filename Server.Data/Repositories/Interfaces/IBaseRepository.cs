using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IIdentifiable
    {
        //T GetFull(long id);

        //T GetProjection(long id);

        //IList<T> GetFull(int offsetCount, int entitiesCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC);

        //IList<T> GetProjection(int offsetCount, int entitiesCount, string orderType = null, SortingOrder sortingOrder = SortingOrder.ASC);

        T Add(T entity);

        T Update(T entity);

        void Remove(long id);

        string SelectAllQuery { get; }
        string SelectByIdQuery { get; }
        string InsertQuery { get; }
        string UpdateByIdQuery { get; }
        string DeleteByIdQuery { get; }
    }
}
