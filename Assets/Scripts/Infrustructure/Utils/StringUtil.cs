using System.Linq;
using System.Collections.Generic;
namespace Infrustructure.Utils
{
    public static class StringUtil
    {
        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = ", ")
        {
            return collection != null ? string.Join(separator, collection) : "NULL COLLECTION";
        }

        public static string StringJoin<T>(this IEnumerable<T> collection, System.Func<T, string> selector,
            string separator = ", ")
        {
            return collection != null ? string.Join(separator, collection.Select(selector)) : "NULL COLLECTION";
        }
    }
}