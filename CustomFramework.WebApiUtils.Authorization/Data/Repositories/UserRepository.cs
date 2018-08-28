using System.Linq;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

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

        public async Task<ICustomList<User>> GetAllByKeywordAsync(string keyword, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.New<User>();
            predicate = predicate.Or(p => p.UserName == keyword);
            predicate = predicate.Or(p => p.Email == keyword);
            predicate = predicate.Or(p => p.Name == keyword);
            predicate = predicate.Or(p => p.Surname == keyword);

            return await (await GetAllWithPagingAsync(predicate: predicate, paging: new Paging(pageIndex, pageSize))).ToCustomList();
        }

        public async Task<ICustomList<User>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }

        public async Task<ICustomList<User>> GetAllAsync(int pageIndex, int pageSize)
        {
            return await (await GetAllWithPagingAsync(paging: new Paging(pageIndex, pageSize))).ToCustomList();
        }

        public async Task<ICustomList<User>> GetAllLast10UserAsync()
        {
            return await GetAll(orderBy: q => q.OrderByDescending(s => s.CreateDateTime), take: 10).ToCustomList();
        }
    }
}