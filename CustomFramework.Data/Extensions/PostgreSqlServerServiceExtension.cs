using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class PostgreSqlServerServiceExtension
    {
        public static IServiceCollection AddPostgreSqlServer<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                    options.UseLazyLoadingProxies();
                }
            );

            services.AddDbContext<TContext>();

            return services;
        }
    }
}