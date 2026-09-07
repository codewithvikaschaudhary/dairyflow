using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Infrastructure.Commons
{
    public static class Paginator
    {
        public static readonly int MAX_PAGE_SIZE = 30;
        public static List<T> GetPaginatorResult<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {

            var currentPageSize = Math.Min(pageSize, MAX_PAGE_SIZE);
            var skip = (pageNumber - 1) * currentPageSize;
            return [.. query.Skip(skip).Take(currentPageSize)];

        }

    }
}
