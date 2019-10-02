using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Identity.Contracts.Utils;
using CustomFramework.WebApiUtils.Contracts;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class BaseChangePasswordRequest
    {

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(OldPassword))]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare(nameof(NewPassword), ErrorMessage = ErrorMessages.Compare)]
        public string ConfirmNewPassword { get; set; }
    }
}