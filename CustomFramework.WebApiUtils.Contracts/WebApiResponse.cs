using Newtonsoft.Json;
using System.Net;

namespace CustomFramework.WebApiUtils.Contracts
{
    public class WebApiResponse
    {
        public HttpStatusCode StatusCode { get; protected set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; protected set; }

        public object Result { get; protected set; }

        public int TotalCount { get; protected set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}
