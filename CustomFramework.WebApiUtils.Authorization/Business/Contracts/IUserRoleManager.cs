using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserRoleManager : IBusinessManager<UserRole, UserRoleRequest, int>
    {
        Task DeleteAsync(int userId, int roleId);
        Task<ICustomList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByUserIdAsync(int userId);

    }
}