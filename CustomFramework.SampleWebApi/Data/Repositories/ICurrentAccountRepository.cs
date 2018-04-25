using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ICurrentAccountRepository : IRepository<CurrentAccount, int>
    {
        Task<CurrentAccount> GetByCodeAsync(string code);
        Task<CurrentAccount> GetByNameAsync(string name);
        Task<ICustomList<CurrentAccount>> GetAllByCustomerIdAsync(int customerId);
    }
}