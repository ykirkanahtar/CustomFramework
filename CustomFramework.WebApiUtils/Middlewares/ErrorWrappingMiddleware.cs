using System;
using System.Net;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CustomFramework.WebApiUtils.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        private readonly ILocalizationService _localizationService;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger, ILocalizationService localizationService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _localizationService = localizationService;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                context.Response.StatusCode = (int)ex.ExceptionToStatusCode();
                context.Response.ContentType = "application/json";

                var apiResponse = new ApiResponse(_localizationService, _logger).Error((HttpStatusCode)context.Response.StatusCode, ex);

                var json = JsonConvert.SerializeObject(apiResponse, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);

            }
        }
    }
}