using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.UserId}");

            RuleFor(x => x.RoleId).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.RoleId}");
        }
    }
}