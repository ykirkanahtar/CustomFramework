using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserRoleManager : IBusinessManager
    {
        Task<bool> AddUserToRoleAsync(UserRoleRequest request);
        Task<bool> RemoveUserFromRoleAsync(int id);
        Task<UserRole> GetByIdAsync(int id);
        Task<CustomEntityList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<CustomEntityList<Role>> GetRolesByUserIdAsync(int userId);
    }
}