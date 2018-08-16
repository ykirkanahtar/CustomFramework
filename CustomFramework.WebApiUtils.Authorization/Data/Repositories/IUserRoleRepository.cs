using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole, int>
    {
        Task<UserRole> GetByUserIdAndRoleIdAsync(int userId, int roleId);
        Task<ICustomList<User>> GetUsersByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByUserIdAsync(int userId);
    }
}