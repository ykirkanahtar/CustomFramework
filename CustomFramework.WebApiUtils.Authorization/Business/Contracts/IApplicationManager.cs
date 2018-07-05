using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IApplicationManager : IBusinessManager<Application, ApplicationRequest, int>
        , IBusinessManagerUpdate<Application, ApplicationRequest, int>
    {
        Task<Application> GetByNameAsync(string name);
        Task<ICustomList<Application>> GetAllAsync();
    }
}