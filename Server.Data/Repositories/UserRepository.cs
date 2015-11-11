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
            var salt = PublishCodeEncrypterPasswordEncrypter.CreateSalt();
            var securedPublishCode = PublishCodeEncrypterPasswordEncrypter.GenerateSHA256Hash(entity.PublishCode, salt);
            var entityId = DBConnection.Query<long>(InsertQuery, new { Username = entity.Username, PublishCode = securedPublishCode, IsDeleted = entity.IsDeleted, Salt = salt }).FirstOrDefault();
            entity.Id = entityId;
            return entity;
        }

        public override User Update(User entity)
        {
            DBConnection.Execute(InsertQuery, new { Username = entity.Username, PublishCode = entity.PublishCode, IsDeleted = entity.IsDeleted });
            return entity;
        }

        public IList<User> GetVIPUsers()
        {
            return DBConnection.Query<User>(this.SelectVIPUsersQuery).ToList<User>();
        }

        

        #region Query properties
        public override string InsertQuery { get { return Sql.InsertStatements.InsertUserQuery; } }
        public override string UpdateByIdQuery { get { return Sql.UpdateStatements.UpdateUserByIdQuery; } }
        public string SelectVIPUsersQuery { get { return Sql.SelectStatements.SelectVIPUsersQuery; } }
        public override string TableName { get { return "Users"; } }
        public override string TableColumns { get { return EntityColumnsConstants.UserColumns; } }
        #endregion
    }
}
