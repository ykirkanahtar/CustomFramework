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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public class CustomUserManager : ICustomUserManager
    {
        private readonly UserManager<User> _userManager;
        public CustomUserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddClaimsAsync(user, claims);
        }

        public async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddLoginAsync(user, login);
        }

        public async Task<IdentityResult> AddPasswordAsync(User user, string password)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddPasswordAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.AddToRolesAsync(user, roles);
        }
        public async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ChangePhoneNumberAsync(User user, string phoneNumber, string token)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.Status = Status.Active;
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            user.Status = Status.Deleted;
            return await _userManager.UpdateAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public async Task<User> GetByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.UpdateAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.AsQueryable().Where(p=>p.Status == Status.Active).ToListAsync();
        }
    }
}