using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICurrentAccountManager : IBusinessManager<CurrentAccount, CurrentAccountRequest, int>
        , IBusinessManagerUpdate<CurrentAccount, CurrentAccountRequest, int>
    {
        Task<CustomEntityList<CurrentAccount>> GetAllAsync();
    }
}
