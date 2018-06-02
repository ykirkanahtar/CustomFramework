using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class UnauthorizedAccessError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.UnauthorizedAccessError;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.Forbidden;
        }
    }
}