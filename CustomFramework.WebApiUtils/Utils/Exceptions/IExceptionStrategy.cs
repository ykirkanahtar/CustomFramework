using System.Net;

namespace CustomFramework.WebApiUtils.Utils.Exceptions
{
    public interface IExceptionStrategy
    {
        string GetReturnMessage(ref string message);

        HttpStatusCode GetHttpStatusCode();
    }
}