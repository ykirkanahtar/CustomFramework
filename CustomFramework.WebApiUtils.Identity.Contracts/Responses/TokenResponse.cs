using System;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Responses
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int ExpireInMinutes { get; set; }
        public DateTime RequestUtcDateTime { get; set; }
        public DateTime ExpireUtcDateTime { get; set; }
        public int UserId { get; set; }
    }
}