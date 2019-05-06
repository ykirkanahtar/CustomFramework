using CustomFramework.LogProvider.Business;
using CustomFramework.LogProvider.Data;
using CustomFramework.LogProvider.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.LogProvider.Extensions
{
    public static class LogProviderServiceExtension
    {
        public static IServiceCollection AddLogModels(this IServiceCollection services)
        {
            /*********Repositories*********/
            services.AddTransient<ILogRepository, LogRepository>();
            /*********Repositories*********/

            /**********Managers***********/
            services.AddTransient<ILogManager, LogManager>();
            /**********Managers***********/

            return services;
        }
    }
}