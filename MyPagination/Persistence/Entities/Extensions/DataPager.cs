using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities.Extensions
{
    public static class DataPager
    {
        public static async Task<Page<T>> PaginateAsync<T>(
            this IQueryable<T> query,
            int page,
            int limit,
            CancellationToken cancellationToken)
            where T : class
        {

            var paged = new Page<T>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.CountAsync(cancellationToken);

            var startRow = (page - 1) * limit;

            paged.Items = await query // perform offset pagination against the data
                       .Skip(startRow)
                       .Take(limit)
                       .ToListAsync(cancellationToken);

            paged.TotalItems = await totalItemsCountTask;

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
