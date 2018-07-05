using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class UserEntityClaimValidator : AbstractValidator<UserEntityClaimRequest>
    {
        public UserEntityClaimValidator()
        {
            RuleFor(x => x.ApplicationId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ApplicationId}");

            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserId}");

            RuleFor(x => x.Entity)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Entity}")
                .MaximumLength(50)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Entity}, 50");
        }
    }
}