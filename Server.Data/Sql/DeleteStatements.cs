using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class DeleteStatements
    {
        public const string DeleteByIdQuery = "UPDATE [dbo].[$TABLENAME] SET [IsDeleted] = 1 WHERE [Id] = @Id";

        public const string ActualDeleteByIdQuery = "DELETE FROM [dbo].[$TABLENAME] WHERE [Id] = @Id";

        public const string DeleteUserByIdQuery = "UPDATE [dbo].[Users] SET [IsDeleted] = 1 WHERE [Id] = @Id; ";

        public const string DeleteAllHaikusByUserIdQuery = "UPDATE [dbo].[Haikus] SET [IsDeleted] = 1 WHERE [UserId] = @Id; ";

        public static readonly string DeleteUserWithHaikusByUserId = "BEGIN TRAN" + DeleteUserByIdQuery + DeleteAllHaikusByUserIdQuery + "COMMIT TRAN";

    }
}
