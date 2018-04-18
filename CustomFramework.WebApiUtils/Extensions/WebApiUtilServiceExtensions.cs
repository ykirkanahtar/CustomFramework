using System.Collections.Generic;
using System.Globalization;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class WebApiUtilServiceExtensions
    {
        public static IServiceCollection AddWebApiUtilServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILocalizationService, LocalizationService>();

            services.AddCustomLocalization("Resources"
                , "tr-TR"
                , new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                });

            services.AddCors();

            return services;
        }
    }
}
