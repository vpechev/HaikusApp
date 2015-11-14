using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Data.Models;
using Server.Data.Sql;
using Server.Data.Utils;

namespace Server.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override User Add(User entity)
        {
            var securedPublishCode = PublishCodeEncrypter.GenerateSHA256Hash(entity.PublishCode);
            var entityId = DBConnection.Query<long>(InsertQuery, new { Username = entity.Username, PublishCode = securedPublishCode, IsDeleted = entity.IsDeleted, IsVip = entity.IsVip }).FirstOrDefault();
            entity.Id = entityId;
            return entity;
        }

        public override User Update(User entity)
        {
            DBConnection.Execute(InsertQuery, new { Username = entity.Username, PublishCode = entity.PublishCode, IsDeleted = entity.IsDeleted, IsVip = entity.IsVip });
            return entity;
        }

        public void UpdateToVip(long id, bool isVip)
        {
            DBConnection.Execute(UpdateVipStatusByIdQuery, new { Id = id, IsVIp = isVip });
        }

        public IList<User> GetVIPUsers()
        {
            return DBConnection.Query<User>(this.SelectVIPUsersQuery).ToList<User>();
        }

        

        #region Query properties
        public override string InsertQuery { get { return Sql.InsertStatements.InsertUserQuery; } }
        public override string UpdateByIdQuery { get { return Sql.UpdateStatements.UpdateUserByIdQuery; } }
        public string UpdateVipStatusByIdQuery { get { return Sql.UpdateStatements.UpdateVipStatusByIdQuery; } }
        public string SelectVIPUsersQuery { get { return Sql.SelectStatements.SelectVIPUsersQuery; } }
        public override string SelectAllQuery { get { return Sql.SelectStatements.SelectAllUsers; } }
        public override string TableName { get { return "Users"; } }
        public override string TableColumns { get { return EntityColumnsConstants.UserColumns; } }
        #endregion
    }
}
