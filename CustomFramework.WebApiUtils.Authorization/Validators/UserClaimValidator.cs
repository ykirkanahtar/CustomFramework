using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class UserClaimValidator : AbstractValidator<UserClaim>
    {
        public UserClaimValidator()
        {
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserId}");

            RuleFor(x => x.ClaimId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClaimId}");

        }
    }
}