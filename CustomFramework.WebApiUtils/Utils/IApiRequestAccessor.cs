namespace CustomFramework.WebApiUtils.Utils
{
    public interface IApiRequestAccessor
    {
        T GetApiRequest<T>();
    }
}