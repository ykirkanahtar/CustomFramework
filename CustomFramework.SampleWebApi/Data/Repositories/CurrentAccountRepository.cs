using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class CurrentAccountRepository : BaseRepository<CurrentAccount, int>, ICurrentAccountRepository
    {
        public CurrentAccountRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<CurrentAccount> GetByCodeAsync(string code)
        {
            return await Get(p => p.Code == code).FirstOrDefaultAsync();
        }

        public async Task<CurrentAccount> GetByNameAsync(string name)
        {
            return await Get(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<CurrentAccount>> GetAllByCustomerIdAsync(int customerId)
        {
            return await GetAll(predicate: p => p.CustomerId == customerId).ToCustomList();
        }
    }
}