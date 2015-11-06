using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class EntityColumnsConstants
    {
        public const string UserColumns = "[Username], [PublishCode], [IsDeleted]";

        public const string HaikuColumns = "[Text], [UserId], [Date], [IsDeleted]";
        
        public const string RatingColumns = "[Value], [HaikuId], [UserId], [IsDeleted]";

    }
}
