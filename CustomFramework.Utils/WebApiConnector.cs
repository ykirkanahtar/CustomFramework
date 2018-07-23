using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomFramework.Utils
{
    public class WebApiConnector<TResponse>
    {
        private string _apiUrl;
        private object _credentials;

        public WebApiConnector(string apiUrl, object credentials)
        {
            _apiUrl = apiUrl;
            _credentials = credentials;
        }

        #region Get Methods
        public async Task<TResponse> GetAsync(string getUrl, bool getToken = false)
        {
            return await GetAsync(getUrl, getToken, string.Empty);
        }

        public TResponse Get(string getUrl, bool getToken = false)
        {
            return GetAsync(getUrl, getToken, string.Empty).Result;
        }

        public async Task<TResponse> GetAsync(string getUrl, string token)
        {
            return await GetAsync(getUrl, false, token);
        }

        public TResponse Get(string getUrl, string token)
        {
            return GetAsync(getUrl, false, token).Result;
        }

        private async Task<TResponse> GetAsync(string getUrl, bool getToken, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                if (getToken)
                {
                    token = await GetApiTokenAsync();
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }

                var response = await client.GetAsync(getUrl);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }
        #endregion

        #region Post Methods
        public async Task<TResponse> PostAsync(string requestPath, string jsonContent, bool getToken = true)
        {
            return await PostAsync(requestPath, jsonContent, getToken, string.Empty);
        }

        public TResponse Post(string requestPath, string jsonContent, bool getToken = true)
        {
            return PostAsync(requestPath, jsonContent, getToken, string.Empty).Result;
        }

        public async Task<TResponse> PostAsync(string requestPath, string jsonContent, string token)
        {
            return await PostAsync(requestPath, jsonContent, false, token);
        }

        public TResponse Post(string requestPath, string jsonContent, string token)
        {
            return PostAsync(requestPath, jsonContent, false, token).Result;
        }

        private async Task<TResponse> PostAsync(string requestPath, string jsonContent, bool getToken, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                if (getToken)
                {
                    token = await GetApiTokenAsync();
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestPath, httpContent);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        #endregion

        #region Put Methods
        public async Task<TResponse> PutAsync(string requestPath, string jsonContent, bool getToken = true)
        {
            return await PutAsync(requestPath, jsonContent, getToken, string.Empty);
        }

        public TResponse Put(string requestPath, string jsonContent, bool getToken = true)
        {
            return PutAsync(requestPath, jsonContent, getToken, string.Empty).Result;
        }

        public async Task<TResponse> PutAsync(string requestPath, string jsonContent, string token)
        {
            return await PutAsync(requestPath, jsonContent, false, token);
        }

        public TResponse Put(string requestPath, string jsonContent, string token)
        {
            return PutAsync(requestPath, jsonContent, false, token).Result;
        }

        private async Task<TResponse> PutAsync(string requestPath, string jsonContent, bool getToken, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                if (getToken)
                {
                    token = await GetApiTokenAsync();
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }

                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(requestPath, httpContent);
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(jsonData);
            }
        }

        #endregion

        public async Task<string> GetApiTokenAsync()
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(_apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonContent = JsonConvert.SerializeObject(_credentials);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //send request
                var responseMessage = await client.PostAsync("api/token", httpContent);

                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObjectResponse = JObject.Parse(responseJson);
                var jObjectResult = JObject.Parse(jObjectResponse.GetValue("result").ToString());
                return jObjectResult.GetValue("token").ToString();
            }
        }

        public async Task<string> GetApiTokenAsync(string apiUrl, object credentials)
        {
            _apiUrl = apiUrl;
            _credentials = credentials;

            return await GetApiTokenAsync();
        }

        public string GetApiToken()
        {
            return GetApiTokenAsync().Result;
        }
    }
}
