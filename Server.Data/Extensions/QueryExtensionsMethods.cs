using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Extensions
{
    public static class QueryExtensionsMethods
    {
        public static string ReplaceTableName(this string invoker, string tableName)
        {
            return invoker.Replace(Sql.Constants.TablePlaceholder, tableName);
        }

        public static string ReplaceStarWithConcreteColumns(this string invoker, string tableColumns)
        {
            return invoker.Replace("*", tableColumns);
        }

        public static string ReplaceOrderTypeValue(this string invoker, string orderType)
        {
            return invoker.Replace("OrderType", orderType);
        }

        public static string ReplaceSortingOrder(this string invoker, string sortingOrder)
        {
            return invoker.Replace("SortingOrder", sortingOrder);
        }
    }
}
