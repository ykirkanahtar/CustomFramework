using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class RoleClaimValidator : AbstractValidator<RoleClaim>
    {
        public RoleClaimValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.RoleId}");

            RuleFor(x => x.ClaimId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClaimId}");

        }
    }
}