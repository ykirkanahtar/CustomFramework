using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Enums;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public class CustomRoleManager<TUser, TRole> : BaseBusinessManager, ICustomRoleManager<TRole>
        where TUser : CustomUser
        where TRole : CustomRole
    {
        private readonly RoleManager<TRole> _roleManager;
        private readonly ICustomUserManager<TUser> _userManager;
        public CustomRoleManager(RoleManager<TRole> roleManager, ICustomUserManager<TUser> userManager, ILogger<CustomRoleManager<TUser, TRole>> logger, IMapper mapper)
            : base(logger, mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(TRole role)
        {
            role.Status = Status.Active;
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);

            (await _userManager.GetUsersInRoleAsync(role.Name)).CheckSubFieldIsExistForDelete("User");

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

        public async Task<IList<TRole>> GetAllAsync()
        {
            return await _roleManager.Roles.AsQueryable().Where(p => p.Status == Status.Active).ToListAsync();
        }
    }
}