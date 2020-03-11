using System.Collections.Generic;
using System.Linq;

namespace Allweb.Core.Common.Extensions
{
    public static class DataExtensions
    {
        // READ Entity Framework Lazy Loading
        public static IEnumerable<T> FullyLoadedList<T>(this IQueryable<T> query) => query.ToArray().ToList();
    }
}
