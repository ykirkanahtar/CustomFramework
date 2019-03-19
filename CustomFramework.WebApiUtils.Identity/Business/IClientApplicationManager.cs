using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface IClientApplicationManager : IBusinessManager<ClientApplication, ClientApplicationRequest, int>
                                                , IBusinessManagerUpdate<ClientApplication, ClientApplicationUpdateRequest, int>
    {
        Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword);

        Task<ClientApplication> GetByClientApplicationCodeAsync(string code);

        Task<ClientApplication> LoginAsync(string code, string password);
    }

}