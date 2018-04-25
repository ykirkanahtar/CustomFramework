using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        Task<Customer> GetByCustomerNoAsync(string customerNo);
        Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageCount);
    }
}