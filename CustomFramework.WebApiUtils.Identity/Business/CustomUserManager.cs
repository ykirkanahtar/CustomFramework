using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public class CustomUserManager<TUser, TRole> : ICustomUserManager<TUser>
        where TUser : CustomUser
    where TRole : CustomRole
    {
        private readonly UserManager<TUser> _userManager;
        private readonly ICustomRoleManager<TRole> _roleManager;

        public CustomUserManager(UserManager<TUser> userManager, ICustomRoleManager<TRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddClaimsAsync(user, claims);
        }

        public async Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddLoginAsync(user, login);
        }

        public async Task<IdentityResult> AddPasswordAsync(TUser user, string password)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddPasswordAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(TUser user, string role)
        {
            await GetByIdAsync(user.Id);
            await _roleManager.GetByNameAsync(role);
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await GetByIdAsync(user.Id);
            foreach (var role in roles)
            {
                await _roleManager.GetByNameAsync(role);
            }
            return await _userManager.AddToRolesAsync(user, roles);
        }
        public async Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ChangePhoneNumberAsync(TUser user, string phoneNumber, string token)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public async Task<bool> CheckPasswordAsync(TUser user, string password)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<IdentityResult> CreateAsync(TUser user, string password, Func<Task> func)
        {
            user.Status = Status.Active;
            await func.Invoke();
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            (await GetRolesAsync(id)).CheckSubFieldIsExistForDelete("Role");

            user.Status = Status.Deleted;
            return await _userManager.UpdateAsync(user);
        }

        public async Task<TUser> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException("User");
            return user;
        }

        public async Task<TUser> GetByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException("User");
            return user;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(TUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(TUser user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IList<string>> GetRolesAsync(int id)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<TUser> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<TUser> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException("User");
            return user;
        }

        public async Task<IList<TUser>> GetUsersInRoleAsync(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName);
            return users.Where(p => p.Status == Status.Active).ToList();
        }

        public async Task<bool> IsEmailConfirmedAsync(TUser user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role)
        {
            await GetByIdAsync(user.Id);
            await _roleManager.GetByNameAsync(role);
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
        {
            await GetByIdAsync(user.Id);
            foreach (var role in roles)
            {
                await _roleManager.GetByNameAsync(role);
            }
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> UpdateAsync(TUser user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IList<TUser>> GetAllAsync()
        {
            return await _userManager.Users.AsQueryable().Where(p => p.Status == Status.Active).ToListAsync();
        }
    }
}