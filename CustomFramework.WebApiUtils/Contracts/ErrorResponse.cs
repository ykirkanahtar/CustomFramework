using System;

namespace CustomFramework.WebApiUtils.Contracts
{
    public class ErrorResponse
    {
        public ErrorResponse(Exception exception)
        {
            ExceptionType = exception.GetType().ToString();
        }

        public ErrorResponse(Exception exception, string errorDetails)
        {
            ExceptionType = exception.GetType().ToString();
            ErrorDetails = errorDetails;
        }

        public ErrorResponse(Exception exception, string errorDetails, string stackTrace)
        {
            ExceptionType = exception.GetType().ToString();
            ErrorDetails = errorDetails;
            StackTrace = stackTrace;
        }

        public string ExceptionType { get; }
        public string ErrorDetails { get; }
        public string StackTrace { get; }
    }
}