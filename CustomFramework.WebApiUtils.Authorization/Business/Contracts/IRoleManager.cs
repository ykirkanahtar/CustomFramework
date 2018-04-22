using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleManager : IBusinessManager<Role, RoleRequest, int>
                                    , IBusinessManagerUpdate<Role, RoleRequest, int>
    {
        Task<Role> GetByNameAsync(string name);
        Task<CustomEntityList<Role>> GetAllAsync();
    }
}