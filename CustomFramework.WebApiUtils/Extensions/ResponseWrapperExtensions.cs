using CustomFramework.WebApiUtils.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class ResponseWrapperExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}