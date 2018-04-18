using Microsoft.Extensions.Localization;

namespace CustomFramework.WebApiUtils.Resources
{
    public interface ILocalizationService
    {
        LocalizedString GetValue(string key);
    }
}