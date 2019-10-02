using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Utils;

namespace CustomFramework.WebApiUtils.Identity.Contracts.Requests
{
    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [EmailAddress(ErrorMessage = ErrorMessages.EmailAddressNotValid)]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(IdentityFieldLengths.PASSWORD_MAX, MinimumLength = IdentityFieldLengths.PASSWORD_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.Compare)]
        [Display(Name = nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [Display(Name = nameof(Code))]
        public string Code { get; set; }
    }
}