using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICustomerManager2 : IBusinessManager<Customer, CustomerRequest, int>
        , IBusinessManagerUpdate<Customer, CustomerRequest, int>
    {
        Customer AddToRepository(Customer entity);
        void DeleteFromRepository(Customer entity);
        Task<CustomEntityList<Customer>> GetAllAsync();
        Task<CustomEntityList<Customer>> GetAllFromRepoAsync();
        Task<Customer> GetFromRepoByIdAsync(int id);
        void UniqueCheckForCustomerNo(string customerNo, int? id = null);
        Customer UpdateRepository(Customer entity);
    }
}