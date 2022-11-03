using Newtonsoft.Json;

namespace WebApiLibrary.Middlewares
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;

        public ErrorHandlingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                context.Response.Headers.Add("Content-Type", "application/json");

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = configuration["ErrorLoggingMiddleware:Message"],
                    description = e.Message
                }));

                await context.Response.CompleteAsync();
            }
        }
    }
}
