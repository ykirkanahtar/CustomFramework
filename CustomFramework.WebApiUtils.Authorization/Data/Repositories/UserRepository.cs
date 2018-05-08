using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await Get(p => p.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await Get(p => p.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            return await Get(p => p.UserName == userName && p.Password == password).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<User>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}