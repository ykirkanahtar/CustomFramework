using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Requests;
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

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Name}")
                .MaximumLength(30)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Name}, 30");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserName}")
                .MaximumLength(30)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.UserName}, 30");

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