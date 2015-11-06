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
    public class HaikuRepository : BaseRepository<Haiku>
    {
        public override Haiku Add(Haiku entity)
        {
            throw new NotImplementedException();
        }

        public override Haiku Update(Haiku entity)
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

        public override string TableName { get { return "Haikus"; } }

        public override string TableColumns { get { return EntityColumnsConstants.HaikuColumns; } }
    }
}
