using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class ClientApplicationValidator : AbstractValidator<ClientApplicationRequest>
    {
        public ClientApplicationValidator()
        {
            RuleFor(x => x.ClientApplicationCode)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClientApplicationCode}")
                .MaximumLength(6)
                .WithMessage(
                    $"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.ClientApplicationCode}, 6");

            RuleFor(x => x.ClientApplicationName)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClientApplicationName}")
                .MaximumLength(20)
                .WithMessage(
                    $"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.ClientApplicationName}, 20");

            RuleFor(x => x.ClientApplicationPassword).NotEmpty()
                .WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.ClientApplicationPassword}");
        }
    }
}