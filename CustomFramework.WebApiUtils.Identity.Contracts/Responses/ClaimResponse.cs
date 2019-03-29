using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Responses
{
    public class ClaimResponse
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
