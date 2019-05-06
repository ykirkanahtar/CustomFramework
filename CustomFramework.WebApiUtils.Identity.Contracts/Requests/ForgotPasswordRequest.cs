using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]

        public string EmailAddress { get; set; }

        public string CallBackUrl { get; set; }

    }
}