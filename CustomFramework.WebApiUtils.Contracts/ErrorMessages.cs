namespace CustomFramework.WebApiUtils.Contracts
{
    public static class ErrorMessages
    {
        public const string Required = "The {0} field is required.";
        public const string StringLength = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";
        public const string RangeWithMinValue = "The field {0} must be greater than or equal to {1}.";
        public const string EmailAddressNotValid = "The {0} field is not a valid e-mail address.";
        public const string Compare = "{0} and {1} do not match.";
    }
}