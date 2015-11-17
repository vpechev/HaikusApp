using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class EntityColumnsConstants
    {
        private const string IdColumnt = " [Id], ";

        public const string UserColumnsWithPublishCode = "[Username], [PublishCode],[IsDeleted], [IsVip], [RatingValue], [RatersCount] ";

        public const string UserColumns = "[Username], [IsDeleted], [IsVip], [RatingValue], [RatersCount] ";
        
        public const string HaikuColumns = "[Text], [UserId], [Date], [IsDeleted], [RatingValue], [RatersCount] ";

        public const string RatingColumns = "[Value], [HaikuId], [IsDeleted]";

        public const String ComplaintForHaikusColumns = " [HaikuId], [Date] ";
        

        public static readonly string UserColumnsWithId = IdColumnt + UserColumns; 
               
        public static readonly string HaikuColumnsWithId = IdColumnt + HaikuColumns;
               
        public static readonly string RatingColumnsWithId = IdColumnt + RatingColumns;
               
        public static readonly String ComplaintForHaikusColumnsWithId = IdColumnt + ComplaintForHaikusColumns; 
    }
}
