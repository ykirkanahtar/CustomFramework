using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleManager : IBusinessManager<Role, RoleRequest, int>
                                    , IBusinessManagerUpdate<Role, RoleRequest, int>
    {
        Task<Role> GetByNameAsync(string name);
        Task<ICustomList<Role>> GetAllAsync();
    }
}