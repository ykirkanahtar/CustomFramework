using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class BaseChangePasswordWithUserNameRequest : BaseChangePasswordRequest
    {
        [Required]
        public string UserName { get; set; }
    }
}