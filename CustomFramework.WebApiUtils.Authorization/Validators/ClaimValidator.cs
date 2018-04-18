using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator()
        {
            RuleFor(x => x.CustomClaim).IsInEnum()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.CustomClaim}");
        }
    }
}