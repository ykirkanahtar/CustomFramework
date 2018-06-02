using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserName}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.UserName}, 25");

            RuleFor(x => x.Password).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Pass}");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Email}")
                .MaximumLength(100)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Email}, 100")
                .EmailAddress().WithMessage($"{ValidatorConstants.EmailFormatError}");
        }
    }
}