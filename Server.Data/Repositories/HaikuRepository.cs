using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Data.Models;
using Server.Data.Sql;
using Server.Data.Managers;

namespace Server.Data.Repositories
{
    public class HaikuRepository : BaseRepository<Haiku>
    {
        public override Haiku Add(Haiku entity, long userId)
        {
            var entityId = DBConnection.Query<long>(InsertQuery, new { Text = entity.Text, UserId = userId, PublishDate = entity.Date, IsDeleted = entity.IsDeleted }).FirstOrDefault();
            entity.Id = entityId;
            return entity;
        }

        public override Haiku Update(Haiku entity, long userId)
        {
            DBConnection.Execute(UpdateByIdQuery, new { Id = entity.Id, Text = entity.Text, UserId = userId, Date = entity.Date, IsDeleted = entity.IsDeleted });
            
            return entity;
        }

        public Haiku UpdateHaikuRating(long haikuId, int rating)
        {
            DBConnection.Execute(UpdateRatingByIdQuery, new { Id = haikuId, Value = rating });
            return this.Get(haikuId);
        }

        //public void AddHaikuCompliant(long haikuId)
        //{
        //    DBConnection.Execute(UpdateCompliantByHaikuIdQuery, new { Id = haikuId});
        //}

        public void DeleteAllHaikusByUserId(long userId)
        {
            DBConnection.Execute(DeleteHaikusByUserIdQuery, new { UserId = userId });
        }

        public override string InsertQuery { get { return Sql.InsertStatements.InsertHaikuQuery; } }

        public override string UpdateByIdQuery { get { return Sql.UpdateStatements.UpdateHaikuByIdQuery; } }

        public string UpdateRatingByIdQuery { get { return Sql.UpdateStatements.UpdateHaikuRatingByIdQuery; } }

        public string UpdateCompliantByHaikuIdQuery { get { return Sql.UpdateStatements.UpdateCompliantByHaikuIdQuery; } }

        public string DeleteHaikusByUserIdQuery { get { return Sql.DeleteStatements.DeleteAllHaikusByUserIdWithRatingRecalculatingQuery; } }
        
        public override string SelectByIdQuery { get { return Sql.SelectStatements.SelectHaikuByIdQuery; } }

        public override string TableName { get { return "Haikus"; } }

        public override string TableColumns { get { return EntityColumnsConstants.HaikuColumnsWithId; } }
    }
}
