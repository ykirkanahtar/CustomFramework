using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class ArgumentError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.ArgumentExceptionError;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}