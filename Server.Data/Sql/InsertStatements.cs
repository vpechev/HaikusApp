using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class InsertStatements
    {
        public const string InsertHaikuQuery = "INSERT INTO [dbo].[" + TableNamesConstants.HaikuTableName + "] VALUES " + EntityColumnsConstants.HaikuColumns + " @Text, @UserId, @PublishDate, @IsDeleted";

        public const string InsertUserQuery = @"BEGIN TRAN
                                                    INSERT INTO [dbo].[" + TableNamesConstants.UserTableName + "] VALUES " + EntityColumnsConstants.UserColumns + @" @Username, @PublishCode, @IsDeleted
                                                    DECLARE @UserId BIGINT = SCOPE_IDENTITY();
                                                    INSERT INTO [dbo].[" + TableNamesConstants.SaltForUserTableName + @" (Salt, UserId) VALUES( @Salt, @UserId);
                                                COMMIT TRAN";

        public const string InsertRatingQuery = "INSERT INTO [dbo].[" + TableNamesConstants.RatingTableName + "] VALUES " + EntityColumnsConstants.RatingColumns + " @[Value], @[HaikuId], @[UserId], @[IsDeleted] ";
    }
}
