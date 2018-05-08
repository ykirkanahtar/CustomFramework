namespace CustomFramework.SampleWebApi.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
	
                RuleFor(x => x.CustomerNo).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CustomerNo}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.CustomerNo}, 25");
	
                RuleFor(x => x.Name).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Name}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Name}, 25");
	
                RuleFor(x => x.Surname).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.Surname}").MaximumLength(25).WithMessage($"{ValidatorConstants.MaxLengthError} : {WebApiResourceConstants.Surname}, 25");
	
                RuleFor(x => x.CurrentAccounts).NotEmpty().WithMessage($"{ValidatorConstants.CannotBeNullError} : {WebApiResourceConstants.CurrentAccounts}");

        }
    }
}
