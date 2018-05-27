using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tester
{
    class Program
    {

        static void Main(string[] args)
        {
            var apiUrl = "https://localhost:44353";
            var createUserPath = "/api/admin/user/create";
            var addUserToRolePath = "/api/admin/userrole/create";

            var baseUserName = "LoadTestUser";
            var password = "Test.1234";
            var emailPrefix = "@gmail.com";
            var loadTestRoleId = 4;

            var login = new Login()
            {
                UserName = "admin",
                UserPassword = "Password.7799",
                ClientApplicationCode = "web",
                ClientApplicationPassword = "1212"
            };

            var token = GetApiTokenAsync(apiUrl, login).Result;

            for (var i = 2; i < 402; i++)
            {
                var updatedUser = PutAsync(apiUrl, $"/api/admin/user/{i}/update/password", password, token).Result;
                Console.WriteLine($"{updatedUser.Id} has been added to LoadTestRole");
            }

            Console.WriteLine("Hello World!");
        }

        private static async Task<UserResponse> PostAsync(string apiUrl, string requestPath, object content, string token)
        {
            UserResponse response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var jsonContent = JsonConvert.SerializeObject(content);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync(requestPath, httpContent);
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                response  = JsonConvert.DeserializeObject<UserResponse>(responseJson);
            }

            return response;
        }

        private static async Task<UserResponse> PutAsync(string apiUrl, string requestPath, object content, string token)
        {
            UserResponse response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                var jsonContent = JsonConvert.SerializeObject(content);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var responseMessage = await client.PutAsync(requestPath, httpContent);
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<UserResponse>(responseJson);
            }

            return response;
        }

        private static async Task<string> GetApiTokenAsync(string apiUrl,Login login)
        {
            TokenResponse tokenResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var jsonContent = JsonConvert.SerializeObject(login);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("api/token", httpContent);

                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObjectResponse = JObject.Parse(responseJson);
                var jObjectResult = JObject.Parse(jObjectResponse.GetValue("result").ToString());
                tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jObjectResult.ToString());
            }

            return tokenResponse.Token;
        }

    }
}
