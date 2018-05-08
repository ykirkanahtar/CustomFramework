using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICurrentAccountManager : IBusinessManager<CurrentAccount, CurrentAccountRequest, int>
        , IBusinessManagerUpdate<CurrentAccount, CurrentAccountRequest, int>
    {
        Task<ICustomList<CurrentAccount>> GetAllByCustomerIdAsync(int customerId);
    }
}
