using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class SqlServerOnCloudServiceExtension
    {
        public static IServiceCollection AddSqlServerOnCloud<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                        sqlServerOptionsAction: sqlOptions =>

                        {
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,

                                maxRetryDelay: TimeSpan.FromSeconds(30),

                                errorNumbersToAdd: null);

                        });
                }
            );

            services.AddDbContext<TContext>();

            return services;
        }
    }
}