using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class ClaimValidator : AbstractValidator<ClaimRequest>
    {
        public ClaimValidator()
        {
            RuleFor(x => x.CustomClaim).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.CustomClaim}");
        }
    }
}