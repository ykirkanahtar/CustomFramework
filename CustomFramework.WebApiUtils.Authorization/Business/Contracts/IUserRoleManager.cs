using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserRoleManager : IBusinessManager<UserRole, UserRoleRequest, int>
    {
        Task<CustomEntityList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<CustomEntityList<Role>> GetRolesByUserIdAsync(int userId);
    }
}