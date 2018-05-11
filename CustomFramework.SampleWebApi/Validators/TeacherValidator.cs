using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace CustomFramework.SampleWebApi.Validators
{
    public class TeacherValidator : AbstractValidator<TeacherRequest>
    {
        public TeacherValidator()
        {

            RuleFor(x => x.TeacherNo).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.TeacherNo}");

            RuleFor(x => x.Name).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}, 25");

            RuleFor(x => x.Surname).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Surname}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Surname}, 25");

        }
    }
}
