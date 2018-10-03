using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class RoleClaimValidator : AbstractValidator<RoleClaimRequest>
    {
        public RoleClaimValidator()
        {
            RuleFor(x => x.ApplicationId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ApplicationId}");

            RuleFor(x => x.RoleId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.RoleId}");

            RuleFor(x => x.ClaimId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClaimId}");

        }
    }
}