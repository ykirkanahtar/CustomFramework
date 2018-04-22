using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICurrentAccountManager2 : IBusinessManager<CurrentAccount, CurrentAccountRequest, int>
        , IBusinessManagerUpdate<CurrentAccount, CurrentAccountRequest, int>
    {
        CurrentAccount AddToRepository(CurrentAccount entity);
        Task CheckCurrentAccount(CurrentAccount currentAccount);
        void DeleteFromRepository(CurrentAccount entity);
        Task<CustomEntityList<CurrentAccount>> GetAllAsync();
        Task<CustomEntityList<CurrentAccount>> GetAllFromRepo();
        Task<CurrentAccount> GetFromRepoById(int id);
        Task UniqueCheckForCurrentAccountcode(string currentAccountCode, int? id = null);
        Task UniqueCheckForCurrentAccountName(string currentAccountName, int? id = null);
        CurrentAccount UpdateRepository(CurrentAccount entity);
    }
}