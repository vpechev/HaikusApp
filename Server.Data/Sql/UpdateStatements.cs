using System;
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
                                                    [PublishCode] = @PublishCode
                                                    WHERE [Id] = @Id ";

        public const string UpdateHaikuByIdQuery = @"UPDATE [dbo].[Haikus]
                                                     SET [Text] = @Text,
                                                     [Date] = @PublishDate
                                                     WHERE [Id] = @Id ";

    }
}
