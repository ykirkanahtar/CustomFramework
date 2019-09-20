using Microsoft.Extensions.Localization;

namespace CustomFramework.WebApiUtils.Contracts.Resources
{
    public interface ILocalizationService
    {
        LocalizedString GetValue(string key);
    }
}