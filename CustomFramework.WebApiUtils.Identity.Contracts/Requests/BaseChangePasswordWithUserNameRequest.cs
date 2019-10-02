using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class BaseChangePasswordWithUserNameRequest : BaseChangePasswordRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]      
        [Display(Name = nameof(UserName))]
        public string UserName { get; set; }
    }
}