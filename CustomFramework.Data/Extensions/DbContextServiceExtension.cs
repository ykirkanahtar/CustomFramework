using System;
using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class DbContextServiceExtension
    {
        public static IServiceCollection AddDatabaseContext<TContext>(this IServiceCollection services, string connectionString
        , DatabaseProvider databaseProvider = DatabaseProvider.MsSql, bool lazyLoading = false, bool useNetTopologySuite = false)
            where TContext : DbContext
        {
            if(useNetTopologySuite && databaseProvider != DatabaseProvider.MsSql)
            {
                throw new Exception("NetTopologySuite can use only with sql server database provider");
            }

            switch (databaseProvider)
            {
                case DatabaseProvider.MsSql:
                    services.AddDbContext<TContext>(options =>
                        {
                            if (useNetTopologySuite)
                                options.UseSqlServer(connectionString, x => x.UseNetTopologySuite());
                            else
                                options.UseSqlServer(connectionString);
                            options.UseLazyLoadingProxies(lazyLoading);
                        }
                    );
                    break;
                case DatabaseProvider.MsSqlAzure:
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
                    break;
                case DatabaseProvider.PostgreSql:
                    services.AddDbContext<TContext>(options =>
                        {
                            options.UseNpgsql(connectionString);
                            options.UseLazyLoadingProxies(lazyLoading);
                        }
                    );
                    break;
                case DatabaseProvider.MySql:
                    services.AddDbContext<TContext>(options =>
                        {
                            options.UseMySQL(connectionString);
                            options.UseLazyLoadingProxies(lazyLoading);
                        }
                    );
                    break;
                case DatabaseProvider.PomeloMySql:
                    services.AddDbContext<TContext>(options =>
                        {
                            options.UseMySql(connectionString);
                            options.UseLazyLoadingProxies(lazyLoading);
                        }
                    );
                    break;
                default:
                    services.AddDbContext<TContext>(options =>
                        {
                            options.UseSqlServer(connectionString);
                            options.UseLazyLoadingProxies(lazyLoading);
                        }
                    );
                    break;
            }

            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<DbContext, TContext>();

            return services;
        }
    }
}
