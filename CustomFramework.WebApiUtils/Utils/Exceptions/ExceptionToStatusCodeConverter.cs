using System;
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