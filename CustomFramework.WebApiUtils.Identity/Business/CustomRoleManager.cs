using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Enums;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public class CustomRoleManager<TRole> : BaseBusinessManagerWithApiRequest<ApiRequest>, ICustomRoleManager<TRole>
        where TRole : CustomRole
    {
        private readonly RoleManager<TRole> _roleManager;
        public CustomRoleManager(RoleManager<TRole> roleManager, ILogger<CustomRoleManager<TRole>> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateAsync(TRole role)
        {
            role.Status = Status.Active;
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);
            role.Status = Status.Deleted;
            return await _roleManager.UpdateAsync(role);
        }

        public async Task<TRole> FindByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<TRole> FindByNameAsync(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<TRole> GetByIdAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if(role == null || role.Status != Status.Active) throw new KeyNotFoundException("Role");
            return role;
        }

        public async Task<TRole> GetByNameAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if(role == null || role.Status != Status.Active) throw new KeyNotFoundException("Role");
            return role;
        }

        public async Task<IdentityResult> UpdateAsync(int id, TRole role)
        {
            return await _roleManager.UpdateAsync(role);
        }
    }
}