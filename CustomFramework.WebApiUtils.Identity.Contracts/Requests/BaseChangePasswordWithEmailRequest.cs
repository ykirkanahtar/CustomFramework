using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class BaseChangePasswordWithEmailRequest : BaseChangePasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}