using CustomFramework.Authorization.Request;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IPermissionManager
    {
        Task<bool> HasPermission(HasPermissionRequest hasPermissionRequest);

    }
}
