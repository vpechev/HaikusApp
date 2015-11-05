using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class SelectStatements
    {
        public const string SelectAllQuery = "SELECT * FROM [dbo].[$TABLENAME]";
        public const string SelectByIdQuery = "SELECT * FROM [dbo].[$TABLENAME] WHERE [Id] = @Id";
    }
}
