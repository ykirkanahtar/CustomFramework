using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class StudentCourseValidator : AbstractValidator<StudentCourseRequest>
    {
        public StudentCourseValidator()
        {

            RuleFor(x => x.StudentId).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.StudentId}");

            RuleFor(x => x.CourseId).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CourseId}");

        }
    }
}
