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
            return new ExceptionOperation(exception).GetHttpStatusCode();
        }
    }
}