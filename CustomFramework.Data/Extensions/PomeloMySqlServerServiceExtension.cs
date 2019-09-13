using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class PomeloMySqlServerServiceExtension
    {
        public static IServiceCollection AddPomeloMySqlServer<TContext>(this IServiceCollection services, string connectionString, bool lazyLoading = false) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                {
                    options.UseMySql(connectionString);
                    options.UseLazyLoadingProxies(lazyLoading);
                }
            );

            services.AddDbContext<TContext>();

            return services;
        }
    }    
}