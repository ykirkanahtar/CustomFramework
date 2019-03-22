using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomRoleManager<TRole> where TRole : CustomRole
    {
        Task<TRole> FindByIdAsync(string id);
        Task<TRole> FindByNameAsync(string name);
        Task<IdentityResult> CreateAsync(TRole role);
        Task<IdentityResult> UpdateAsync(int id, TRole role);
        Task<IdentityResult> DeleteAsync(int id);
        Task<TRole> GetByIdAsync(int id);
        Task<TRole> GetByNameAsync(string name);
    }
}