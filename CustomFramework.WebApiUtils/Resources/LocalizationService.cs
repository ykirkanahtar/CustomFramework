using System.Reflection;
using Microsoft.Extensions.Localization;

namespace CustomFramework.WebApiUtils.Resources
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResources);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResources", assemblyName.Name);

        }

        public LocalizedString GetValue(string key)
        {
            return _localizer[key];
        }
    }
}