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

        public const string DeleteUserByIdQuery = " UPDATE [dbo].[Users] SET [IsDeleted] = 1 WHERE [Id] = @Id; ";

        public const string DeleteAllHaikusByUserIdWithRatingRecalculatingQuery = @"BEGIN TRAN
                                                                                    " + DeleteHaikusByUserId + @"
                                                                                    UPDATE [dbo].[Users] SET [RatingValue] = 0, [RatersCount] = 0 WHERE UserId = @UserId
                                                                                    COMMIT TRAN";

        private const string DeleteHaikusByUserId = " UPDATE [dbo].[Haikus] SET [IsDeleted] = 1 WHERE [UserId] = @UserId; ";

        public static readonly string DeleteUserWithHaikusByUserId = "BEGIN TRAN" + DeleteUserByIdQuery + DeleteHaikusByUserId + "COMMIT TRAN";
    }
}
