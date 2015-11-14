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

        public static readonly string SelectUserIdByPublishCode = "Select [Id] FROM [dbo].[" + TableNamesConstants.UserTableName + " WHERE [PublishCode] = @PublishCode";

        public const string SelectAllUsers = "(SELECT *, 1 as filter FROM " + TableNamesConstants.UserTableName + @" WHERE [IsVip] = 1 AND [IsDeted] = 0 )
                                              UNION ALL
                                              (SELECT *, 2 as filter FROM " + TableNamesConstants.UserTableName + @" WHERE [IsVip] = 0 AND [IsDeted] = 0 )  
                                              ORDER BY filter, [OrderType] SortingOrder OFFSET @OffsetCount ROWS FETCH NEXT @FetchedElements ROWS ONLY";
    }
}
