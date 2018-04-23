using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class CurrentAccountValidator : AbstractValidator<CurrentAccountRequest>
    {
        public CurrentAccountValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CurrentAccountName}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CurrentAccountName}, 25");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(
                    $"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CurrentAccountCode}")
                .MaximumLength(25)
                .WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CurrentAccountCode}, 25");


            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CustomerId}");
        }
    }
}