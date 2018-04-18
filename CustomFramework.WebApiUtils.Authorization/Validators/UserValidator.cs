using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserName}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.UserName}, 25");

            RuleFor(x => x.Password).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Password}");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Email}")
                .MaximumLength(100)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Email}, 100")
                .EmailAddress().WithMessage($"{ValidatorConstants.EmailFormatError}");

            RuleFor(x => x.EmailConfirmCode)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.EmailConfirmCode}")
                .Length(6).WithMessage(
                    $"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.EmailConfirmCode}, 6");
        }
    }
}