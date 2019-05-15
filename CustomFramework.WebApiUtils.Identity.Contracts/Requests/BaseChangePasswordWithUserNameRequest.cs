using System.ComponentModel.DataAnnotations;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class BaseChangePasswordWithUserNameRequest : BaseChangePasswordRequest
    {
        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public string UserName { get; set; }
    }
}