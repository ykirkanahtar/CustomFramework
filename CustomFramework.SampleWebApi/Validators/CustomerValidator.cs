using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerNo)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CustomerNo}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CustomerNo}, 25");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CustomerName}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CustomerName}, 25");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CustomerSurname}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CustomerSurname}, 25");
        }
    }
}