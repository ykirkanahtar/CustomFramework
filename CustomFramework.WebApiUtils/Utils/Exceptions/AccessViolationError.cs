using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class AccessViolationError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.AccessViolationError;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}