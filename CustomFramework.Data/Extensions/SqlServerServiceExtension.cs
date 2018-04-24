using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class SqlServerServiceExtension
    {
        public static IServiceCollection AddSqlServer<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                }
            );

            services.AddDbContext<TContext>();

            return services;
        }
    }
}