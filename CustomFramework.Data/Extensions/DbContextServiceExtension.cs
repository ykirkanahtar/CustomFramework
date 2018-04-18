using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.Data.Extensions
{
    public static class DbContextServiceExtension
    {
        public static IServiceCollection AddDbContext<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<DbContext, TContext>();

            return services;
        }
    }
}
