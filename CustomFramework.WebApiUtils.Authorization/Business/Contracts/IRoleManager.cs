using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleManager : IBusinessManager<Role, RoleRequest, int>
                                    , IBusinessManagerUpdate<Role, RoleRequest, int>
    {
        Task<Role> GetByNameAsync(string name);
        Task<ICustomList<Role>> GetAllAsync();
    }
}