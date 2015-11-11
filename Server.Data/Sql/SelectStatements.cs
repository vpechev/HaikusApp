using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class SelectStatements
    {
        public static readonly string SelectAllQuery = "SELECT * FROM [dbo].[$TABLENAME] WHERE [IsDeleted] = 0 " + Constants.PagingQuery;
        
        public const string SelectByIdQuery = "SELECT * FROM [dbo].[$TABLENAME] WHERE [Id] = @Id AND [IsDeleted] = 0";

        public const string SelectVIPUsersQuery = "SELECT * FROM [dbo].[Users] WHERE [IsVIP] = 1 AND [IsDeleted] = 0";

        public static readonly string SelectAllComplaints = "SELECT * FROM [dbo].[Haikus] WHERE [IsComplaint] = 1 AND [IsDeleted] = 0 " + Constants.PagingQuery;

        public static readonly string SelectSaltByUserId = "Select [Salt] FROM [dbo].[" + TableNamesConstants.SaltForUserTableName + " WHERE [UserId] = @Id";
        public static readonly string SelectPublishCodeByUserId = "Select [PublishCode] FROM [dbo].[" + TableNamesConstants.UserTableName + " WHERE [Id] = @Id";
    }
}
