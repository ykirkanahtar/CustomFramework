using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ClaimRequest
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}