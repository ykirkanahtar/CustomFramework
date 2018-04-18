using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Security.Authentication;
using CustomFramework.WebApiUtils.Constants;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Contracts
{
    public class ApiResponse : IApiResponse
    {
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;

        public ApiResponse(ILocalizationService localizationService, ILogger logger)
        {
            _localizationService = localizationService;
            _logger = logger;
        }

        public HttpStatusCode StatusCode { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; private set; }

        public object Result { get; private set; }

        public int TotalCount { get; private set; }

        public ErrorResponse ErrorResponse { get; set; }

        public ApiResponse Ok(object result)
        {
            StatusCode = HttpStatusCode.OK;
            Result = result;
            TotalCount = 1;
            Message = _localizationService.GetValue(DefaultResponseMessages.SuccessMessage);

            _logger.LogInformation(Message, Result);
            return this;
        }

        public ApiResponse Ok<T>(IList<T> list, int totalCount)
        {
            StatusCode = HttpStatusCode.OK;
            Result = list;
            TotalCount = totalCount;
            Message = _localizationService.GetValue(DefaultResponseMessages.SuccessMessage);

            _logger.LogInformation(Message, Result);
            return this;
        }

        public ApiResponse Error(HttpStatusCode statusCode, Exception exception)
        {
            ErrorResponse = new ErrorResponse(exception);
            StatusCode = statusCode;
            Message = $"{_localizationService.GetValue(DefaultResponseMessages.AnErrorHasOccured)} : {GetDefaultMessageForException(exception)}";

            _logger.LogError(0, exception, Message);
            return this;
        }

        public ApiResponse Error(HttpStatusCode statusCode, string message, Exception exception)
        {
            ErrorResponse = new ErrorResponse(
                exception
            );

            StatusCode = statusCode;
            Message = $"{_localizationService.GetValue(DefaultResponseMessages.AnErrorHasOccured)} : {GetDefaultMessageForException(exception)} {_localizationService.GetValue(message)}";

            _logger.LogError(0, exception, Message);
            return this;
        }

        public ApiResponse ModelStateError(ModelStateDictionary modelState, Exception exception)
        {
            ErrorResponse = new ErrorResponse(
                null
                , modelState.ModelStateToString()
            );

            StatusCode = HttpStatusCode.BadRequest;
            Message = _localizationService.GetValue(DefaultResponseMessages.ModelStateErrors);

            _logger.LogError(0, exception, Message);
            return this;
        }

        private string GetDefaultMessageForException(Exception exception)
        {
            var returnMessage = DefaultResponseMessages.AnErrorHasOccured;

            var message = exception.Message;

            if (message.Contains("See the inner exception for details"))
                message = exception.InnerException.Message;

            if (message.Contains("See the inner exception for details"))
                message = exception.InnerException.InnerException.Message;

            if (message.Contains("See the inner exception for details"))
                message = exception.InnerException.InnerException.InnerException.Message;

            if (exception is DuplicateNameException)
                returnMessage = DefaultResponseMessages.RecordExistsError;
            else if (exception is KeyNotFoundException)
                returnMessage = DefaultResponseMessages.NotFoundError;
            else if (exception is ArgumentException)
                returnMessage = DefaultResponseMessages.ArgumentExceptionError;
            else if (exception is AuthenticationException)
            {
                returnMessage = DefaultResponseMessages.LoginError;
                message = string.Empty;
            }
            else if (exception is UnauthorizedAccessException)
            {
                returnMessage = DefaultResponseMessages.UnauthorizedAccessError;
                message = string.Empty;
            }

            var localizatedReturnMessage = _localizationService.GetValue(returnMessage);
            return string.IsNullOrEmpty(message) ? $"{localizatedReturnMessage}" : $"{localizatedReturnMessage} : {_localizationService.GetValue(message)}";
        }
    }
}