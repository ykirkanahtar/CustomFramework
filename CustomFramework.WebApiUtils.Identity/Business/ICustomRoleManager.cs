using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomRoleManager
    {
        Task<Role> FindByIdAsync(string id);
        Task<Role> FindByNameAsync(string name);
        Task<IdentityResult> CreateAsync(Role role);
        Task<IdentityResult> UpdateAsync(int id, Role role);
        Task<IdentityResult> DeleteAsync(int id);
        Task<Role> GetByIdAsync(int id);
        Task<Role> GetByNameAsync(string name);
    }
}