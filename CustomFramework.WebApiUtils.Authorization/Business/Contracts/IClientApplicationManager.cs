using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationManager : IBusinessManager<ClientApplication, ClientApplicationRequest, int>
                                                , IBusinessManagerUpdate<ClientApplication, ClientApplicationUpdateRequest, int>
    {
        Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword);

        Task<ClientApplication> GetByClientApplicationCodeAsync(string code);

        Task<ClientApplication> LoginAsync(string code, string password);
    }
}