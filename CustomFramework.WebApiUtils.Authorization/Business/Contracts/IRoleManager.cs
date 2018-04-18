using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleManager : IBusinessManager
    {
        Task<Role> CreateAsync(RoleRequest request);
        Task<Role> UpdateAsync(int id, RoleRequest request);
        Task DeleteAsync(int id);
        Task<Role> GetByIdAsync(int id);
        Task<Role> GetByNameAsync(string name);
        Task<CustomEntityList<Role>> GetAllAsync();
    }
}