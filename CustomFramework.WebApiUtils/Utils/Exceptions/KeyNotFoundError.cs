using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class KeyNotFoundError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.NotFoundError;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}