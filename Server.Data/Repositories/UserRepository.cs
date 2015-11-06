using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Data.Models;
using Server.Data.Sql;

namespace Server.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public override User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public override User Update(User entity)
        {
            throw new NotImplementedException();
        }

        public override string InsertQuery
        {
            get { throw new NotImplementedException(); }
        }

        public override string UpdateByIdQuery
        {
            get { throw new NotImplementedException(); }
        }

        public override string TableName { get { return "Users"; } }

        public override string TableColumns { get { return EntityColumnsConstants.UserColumns; } }
    }
}
