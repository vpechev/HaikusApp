using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class InsertStatements
    {
        public const string InsertHaikuQuery = "INSERT INTO [dbo].[" + TableNamesConstants.HaikuTableName + "] (" + EntityColumnsConstants.HaikuColumns + ") OUTPUT INSERTED.Id  VALUES (@Text, @UserId, @PublishDate, @IsDeleted,0,0)";

        public const string InsertUserQuery = @" INSERT INTO [dbo].[" + TableNamesConstants.UserTableName + "] (" + EntityColumnsConstants.UserColumnsWithPublishCode + @") OUTPUT INSERTED.Id  VALUES (@Username, @PublishCode, @IsDeleted, @IsVip, 0, 0)";

        public const string InsertRatingQuery = "INSERT INTO [dbo].[" + TableNamesConstants.RatingTableName + "] (" + EntityColumnsConstants.RatingColumns + ") OUTPUT INSERTED.Id  VALUES (@Value, @HaikuId, 0)";

        public const string InsertComplaintQuery = " INSERT INTO [dbo].[ComplaintForHaikus] ([HaikuId], [Date]) OUTPUT INSERTED.Id  VALUES (@HaikuId, @Date) ";
    }
}
