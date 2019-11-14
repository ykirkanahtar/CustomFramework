using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Contracts
{
    public interface IWebApiConnector<TResponse>
    {
        TResponse Get(string url, string tokenUrl, object credentials, string language);
        Task<TResponse> GetAsync(string url, string tokenUrl, object credentials, string language);
        TResponse Get(string url, string language, string token);
        Task<TResponse> GetAsync(string url, string language, string token = null);
        TResponse GetApiToken(string url, object credentials, string language);
        Task<TResponse> GetApiTokenAsync(string url, object credentials, string language);
        string GetTokenFromJson(string responseJson);
        int GetTokenExpireInMinutesFromJson(string responseJson);

        TResponse Post(string url, string jsonContent, string tokenUrl, object credentials, string language);
        Task<TResponse> PostAsync(string url, string jsonContent, string tokenUrl, object credentials, string language);
        TResponse Post(string url, string jsonContent, string token, string language);
        Task<TResponse> PostAsync(string url, string jsonContent, string language, string token = null);

        TResponse Put(string url, string jsonContent, string tokenUrl, object credentials, string language);
        Task<TResponse> PutAsync(string url, string jsonContent, string tokenUrl, object credentials, string language);
        TResponse Put(string url, string jsonContent, string token, string language);
        Task<TResponse> PutAsync(string url, string jsonContent, string language, string token = null);
    }

}