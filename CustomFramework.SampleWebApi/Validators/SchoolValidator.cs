using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class SchoolValidator : AbstractValidator<SchoolRequest>
    {
        public SchoolValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}, 25");
            RuleFor(x => x.Address).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Address}")
                .MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Address}, 25");
        }
    }
}
