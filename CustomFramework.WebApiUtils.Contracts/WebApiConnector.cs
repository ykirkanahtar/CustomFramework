using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomFramework.WebApiUtils.Contracts
{
    public class WebApiConnector<TResponse> : IWebApiConnector<TResponse>
    {
        #region Get Methods

        public TResponse Get(string url, string tokenUrl, object credentials, string language)
        {
            var token = GetApiToken(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(token);
            return Get(url, GetTokenFromJson(tokenJson), language);
        }

        public async Task<TResponse> GetAsync(string url, string tokenUrl, object credentials, string language)
        {
            var token = await GetApiTokenAsync(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(token);
            return await GetAsync(url, GetTokenFromJson(tokenJson));
        }

        public TResponse Get(string url, string language, string token)
        {
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = client.GetAsync(url).Result;
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        public async Task<TResponse> GetAsync(string url, string language, string token = null)
        {
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await client.GetAsync(url);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        public TResponse GetApiToken(string url, object credentials, string language)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                var jsonContent = JsonConvert.SerializeObject(credentials);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //send request
                var responseMessage = client.PostAsync(url, httpContent).Result;

                //get access token from response body
                var responseJson = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
        }

        public async Task<TResponse> GetApiTokenAsync(string url, object credentials, string language)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                var jsonContent = JsonConvert.SerializeObject(credentials);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //send request
                var responseMessage = await client.PostAsync(url, httpContent);

                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseJson);
            }
        }

        public string GetTokenFromJson(string responseJson)
        {
            var jObjectResponseLv1 = JObject.Parse(responseJson);

            var resultLv1 = jObjectResponseLv1.GetValue("Result")?.ToString();

            var jObjectResponseLv2 = JObject.Parse(resultLv1);

            var resultLv2 = jObjectResponseLv2.GetValue("tokenResponse")?.ToString();

            if (string.IsNullOrEmpty(resultLv2)) throw new Exception("Token alınırken hata oluştu");

            var jObjectResult = JObject.Parse(resultLv2);
            return jObjectResult.GetValue("token").ToString();
        }

        public int GetTokenExpireInMinutesFromJson(string responseJson)
        {
            var jObjectResponse = JObject.Parse(responseJson);

            var result = jObjectResponse.GetValue("Result")?.ToString();

            if (string.IsNullOrEmpty(result)) return 0;

            var jObjectResult = JObject.Parse(result);
            return Convert.ToInt32(jObjectResult.GetValue("expireInMinutes"));
        }

        #endregion

        #region Post Methods

        public TResponse Post(string url, string jsonContent, string tokenUrl, object credentials, string language)
        {
            var token = GetApiToken(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(token);
            return Post(url, jsonContent, GetTokenFromJson(tokenJson), language);
        }

        public async Task<TResponse> PostAsync(string url, string jsonContent, string tokenUrl, object credentials, string language)
        {
            var tokenResponse = await GetApiTokenAsync(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(tokenResponse);
            var token = GetTokenFromJson(tokenJson);
            return await PostAsync(url, jsonContent, token);
        }

        public TResponse Post(string url, string jsonContent, string token, string language)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, httpContent).Result;

                // if (response.StatusCode == HttpStatusCode.NotFound)
                // {
                //     throw new Exception(response.ReasonPhrase);
                // }

                var jsonData = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        public async Task<TResponse> PostAsync(string url, string jsonContent, string language, string token = null)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, httpContent);

                // if (response.StatusCode == HttpStatusCode.NotFound)
                // {
                //     throw new Exception(response.ReasonPhrase);
                // }

                var jsonData = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        #endregion

        #region Put Methods

        public TResponse Put(string url, string jsonContent, string tokenUrl, object credentials, string language)
        {
            var token = GetApiToken(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(token);
            return Put(url, jsonContent, GetTokenFromJson(tokenJson), language);
        }

        public async Task<TResponse> PutAsync(string url, string jsonContent, string tokenUrl, object credentials, string language)
        {
            var token = await GetApiTokenAsync(tokenUrl, credentials, language);
            var tokenJson = JsonConvert.SerializeObject(token);
            return await PutAsync(url, jsonContent, GetTokenFromJson(tokenJson), language);
        }

        public TResponse Put(string url, string jsonContent, string token, string language)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = client.PutAsync(url, httpContent).Result;
                var jsonData = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        public async Task<TResponse> PutAsync(string url, string jsonContent, string language, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Accept-Language", LanguageConverter(language));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, httpContent);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        #endregion

        private string LanguageConverter(string language)
        {
            if (language.ToLower() == "tr") return "tr-TR";
            if (language.ToLower() == "en") return "en-US";

            return language;
        }

    }

}
