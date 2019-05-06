using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserRole> GetByUserIdAndRoleIdAsync(int userId, int roleId)
        {
            return await Get(p => p.UserId == userId && p.RoleId == roleId).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return await GetAll(p => p.RoleId == roleId).Include(p => p.User).Select(p => p.User)
                .ToCustomList();
        }

        public async Task<ICustomList<Role>> GetRolesByUserIdAsync(int userId)
        {
            return await GetAll(p => p.UserId == userId).Include(p => p.Role).Select(p => p.Role)
                .ToCustomList();
        }
    }
}