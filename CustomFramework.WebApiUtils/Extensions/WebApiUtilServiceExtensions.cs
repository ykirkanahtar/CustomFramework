using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class WebApiUtilServiceExtensions
    {
        public static IServiceCollection AddWebApiUtilServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();

            return services;
        }
    }
}
