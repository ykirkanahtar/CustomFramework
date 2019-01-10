using Newtonsoft.Json;
using System.Net;

namespace CustomFramework.WebApiUtils.Contracts
{
    public class WebApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public object Result { get; set; }

        public int TotalCount { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}
