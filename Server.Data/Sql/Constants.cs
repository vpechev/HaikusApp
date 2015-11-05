using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Sql
{
    public class Constants
    {
        public const string TablePlaceholder = "$TABLENAME";

        public static readonly string PagingQuery = " ORDER BY [OrderType] SortingOrder OFFSET @OffsetCount ROWS FETCH NEXT @FetchedElements ROWS ONLY ";

    }
}
