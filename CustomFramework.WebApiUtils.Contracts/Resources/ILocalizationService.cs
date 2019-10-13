using Microsoft.Extensions.Localization;

namespace CustomFramework.WebApiUtils.Contracts.Resources
{
    public interface ILocalizationService
    {
        string GetValue(string key);
    }
}