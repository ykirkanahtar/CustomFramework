using CustomFramework.WebApiUtils.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
