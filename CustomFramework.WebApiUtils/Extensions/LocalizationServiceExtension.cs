using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class LocalizationServiceExtension
    {
        public static IServiceCollection AddCustomLocalization(this IServiceCollection services, string resourcePath, string defaultCulture, IList<CultureInfo> cultureInfos)
        {
            services.AddLocalization(options => options.ResourcesPath = resourcePath);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: defaultCulture, uiCulture: defaultCulture);
                options.SupportedCultures = cultureInfos;
                options.SupportedUICultures = cultureInfos;
                options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
            });

            return services;
        }
    }
}