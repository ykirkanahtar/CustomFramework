using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public static class ExceptionToStatusCodeConverter
    {
        public static HttpStatusCode ExceptionToStatusCode(this Exception exception)
        {
            switch (exception)
            {
                case KeyNotFoundException _:
                    return HttpStatusCode.NotFound;
                case DuplicateNameException _:
                    return HttpStatusCode.BadRequest;
                case ArgumentException _:
                    return HttpStatusCode.BadRequest;
                case UnauthorizedAccessException _:
                    return HttpStatusCode.Unauthorized;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

    }
}