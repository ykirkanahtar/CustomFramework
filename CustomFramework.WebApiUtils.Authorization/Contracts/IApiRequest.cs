using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Contracts
{
    public interface IApiRequest
    {
        User User { get; set; }
        ClientApplication ClientApplication { get; set; }
    }
}