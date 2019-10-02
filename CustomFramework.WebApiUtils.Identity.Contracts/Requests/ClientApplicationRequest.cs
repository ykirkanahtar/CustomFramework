using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Utils;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ClientApplicationRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.CLIENT_APPLICATION_NAME_MAX, MinimumLength = IdentityFieldLengths.CLIENT_APPLICATION_NAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(ClientApplicationName))]
        public string ClientApplicationName { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.CLIENT_APPLICATION_CODE_MAX, MinimumLength = IdentityFieldLengths.CLIENT_APPLICATION_CODE_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(ClientApplicationCode))]
        public string ClientApplicationCode { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ClientApplicationPassword))]
        public string ClientApplicationPassword { get; set; }

    }
}