using System.Net;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public class DuplicateNameError : IExceptionStrategy
    {
        public string GetReturnMessage(ref string message)
        {
            return DefaultResponseMessages.RecordExistsError;
        }

        public HttpStatusCode GetHttpStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}