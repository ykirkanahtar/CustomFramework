using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        public StudentValidator()
        {

            RuleFor(x => x.StudentNo).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.StudentNo}");

            RuleFor(x => x.Name).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}, 25");

            RuleFor(x => x.Surname).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Surname}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Surname}, 25");

        }
    }
}
