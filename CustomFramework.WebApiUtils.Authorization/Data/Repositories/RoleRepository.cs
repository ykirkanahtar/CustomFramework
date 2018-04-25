using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            return await Get(p => p.RoleName == name).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Role>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}