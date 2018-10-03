using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.WebApiUtils.Authorization.Validators
{
    public class ApplicationValidator : AbstractValidator<ApplicationRequest>
    {
        public ApplicationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {AuthorizationConstants.Name}")
                .MaximumLength(50).WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Name}, 50");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage($"{ValidatorConstants.MaxLengthError} : {AuthorizationConstants.Description}, 500");
        }
    }
}