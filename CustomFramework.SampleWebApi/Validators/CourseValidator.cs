using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class CourseValidator : AbstractValidator<CourseRequest>
    {
        public CourseValidator()
        {

            RuleFor(x => x.CourseNo).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CourseNo}");

            RuleFor(x => x.Name).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}, 25");

            RuleFor(x => x.TeacherId).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.TeacherId}");

        }
    }
}
