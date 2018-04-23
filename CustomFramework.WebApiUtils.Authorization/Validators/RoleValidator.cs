using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class RoleValidator : AbstractValidator<RoleRequest>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.RoleName}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.RoleName}, 25");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Description}")
                .MaximumLength(255)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Description}, 255");
        }
    }
}