namespace CustomFramework.WebApiUtils.Authorization.Utils
{
    public interface IApiRequestAccessor
    {
        T GetApiRequest<T>();
    }
}