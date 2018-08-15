using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole, int>
    {
        Task<UserRole> GetByUserIdAndRoleIdAsync(int userId, int roleId);
        Task<ICustomList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByUserIdAsync(int userId);
    }
}