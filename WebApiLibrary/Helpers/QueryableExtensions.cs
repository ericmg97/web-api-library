using WebApiLibrary.DTOs;

namespace WebApiLibrary.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable
                .Skip(paginacionDTO.Offset)
                .Take(paginacionDTO.Limit);
        }
    }
}
