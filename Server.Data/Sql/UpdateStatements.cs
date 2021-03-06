﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class UpdateStatements
    {
        public const string UpdateUserByIdQuery = @"UPDATE [dbo].[Users]
                                                    SET [Username] = @Username,
                                                    [IsVip] = @IsVip
                                                    WHERE [Id] = @Id ";

        public const string UpdateVipStatusByIdQuery = @"UPDATE [dbo].[Users]
                                                        SET [IsVip] = @IsVip
                                                        WHERE [Id] = @Id ";

        public const string UpdateHaikuByIdQuery = @"
                                                     BEGIN TRAN
                                                     DECLARE @CurrentRatingValue BIGINT = (SELECT [RatingValue] FROM [dbo].[" + TableNamesConstants.HaikuTableName + @"] WHERE [Id] = @Id)
                                                    
                                                     DELETE FROM [dbo].[" + TableNamesConstants.RatingTableName + @"] WHERE [HaikuId] = @Id;

                                                     UPDATE [dbo].[" + TableNamesConstants.UserTableName + @"] SET [RatersCount] = [RatersCount] - 1, [RatingValue] = [RatingValue] - @CurrentRatingValue WHERE [Id] = @UserId; 

                                                     UPDATE [dbo].[Ratings] SET [IsDeleted] = 1 WHERE [HaikuId] = @Id;
                                                     UPDATE [dbo].[Haikus]
                                                     SET [Text] = @Text,
                                                     [Date] = @Date,
                                                     [RatingValue] = 0,
                                                     [RatersCount] = 0
                                                     WHERE [Id] = @Id 
                                                     COMMIT TRAN";


        public const string UpdateHaikuRatingByIdQuery = @"BEGIN TRAN
                                                                DECLARE @HaikuId BIGINT = @Id;
                                                                DECLARE @UserId BIGINT = (SELECT [UserId] FROM [dbo].[Haikus] WHERE [Id] = @Id);
                                                                " + InsertStatements.InsertRatingQuery + @"
                                                                UPDATE [dbo].[" + TableNamesConstants.HaikuTableName + @"] SET [RatersCount] = [RatersCount] + 1, [RatingValue] = [RatingValue] + @Value WHERE [Id] = @Id; 
                                                                UPDATE [dbo].[" + TableNamesConstants.UserTableName + @"] SET [RatersCount] = [RatersCount] + 1, [RatingValue] = [RatingValue] + @Value WHERE [Id] = @UserId; 
                                                           COMMIT TRAN";

        public const string UpdateCompliantByHaikuIdQuery = @"IF NOT EXISTS(SELECT * FROM [dbo].[ComplaintForHaikus] WHERE [HaikuId] = @Id)
                                                                 INSERT INTO ([HaikuId]) VALUES (@Id)";
    }
}
