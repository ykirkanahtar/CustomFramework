using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class DefaultError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.AnErrorHasOccured;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.InternalServerError;
        }
    }
}