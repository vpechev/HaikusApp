using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class InsertStatements
    {
        public const string InsertHaikuQuery = "INSERT INTO [dbo].[" + TableNamesConstants.HaikuTableName + "] VALUES " + EntityColumnsConstants.HaikuColumns + " @Text, @UserId, @PublishDate, 0";

        public const string InsertUserQuery = "INSERT INTO [dbo].[" + TableNamesConstants.UserTableName + "] VALUES " + EntityColumnsConstants.UserColumns + "@Username, @PublishCode, 0";

    }
}
