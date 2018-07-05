using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Contracts
{
    public interface IApiRequest
    {
        int ApplicationId { get; set; }
        User User { get; set; }
        ClientApplication ClientApplication { get; set; }
    }
}