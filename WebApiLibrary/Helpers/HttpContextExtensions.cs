using Microsoft.EntityFrameworkCore;

namespace WebApiLibrary.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task AddPaginationParams<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int offset)
        {
            double count = await queryable.CountAsync() - 1;
            double maxLimit = count - offset;
            httpContext.Response.Headers.Add("maxOffset", count.ToString());
            httpContext.Response.Headers.Add("maxLimit", maxLimit.ToString());
        }
    }
}
