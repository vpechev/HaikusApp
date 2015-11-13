using Server.Data.Models;
using Server.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Data.Enums;

namespace Server.Data.Repositories
{
    class ComplaintRepository : BaseRepository<Complaint>
    {
        public override Complaint Add(Complaint entity)
        {
            var entityId = DBConnection.Query<long>(InsertQuery, new { HaikuId = entity.HaikuId, Date = entity.Date }).FirstOrDefault();
            entity.Id = entityId;                                        
            return entity;
        }

        public override Complaint Update(Complaint entity)
        {
            throw new Exception("Complaints cannot be updated");
        }

        public IList<Complaint> Get(int skipCount, int takeCount, Enums.SortingOrder sortingOrder = SortingOrder.ASC)
        {
            return base.Get(skipCount, takeCount, "Date", sortingOrder);
        }

        #region Query properties
        public override string InsertQuery { get { return Sql.InsertStatements.InsertComplaintQuery; } }
        public override string UpdateByIdQuery { get { return ""; } }
        public override string TableName { get { return "ComplaintForHaikus"; } }
        public override string TableColumns { get { return EntityColumnsConstants.ComplaintForHaikusColumns; } }
        #endregion
    }
}
