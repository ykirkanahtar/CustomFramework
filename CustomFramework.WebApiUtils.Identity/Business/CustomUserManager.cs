using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Enums;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public class CustomUserManager : UserManager<User>, ICustomUserManager
    {
        public CustomUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public override async Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            await GetByIdAsync(user.Id);
            return await base.AddClaimsAsync(user, claims);
        }

        public override async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
        {
            await GetByIdAsync(user.Id);
            return await base.AddLoginAsync(user, login);
        }

        public override async Task<IdentityResult> AddPasswordAsync(User user, string password)
        {
            await GetByIdAsync(user.Id);
            return await base.AddPasswordAsync(user, password);
        }

        public override async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            await GetByIdAsync(user.Id);
            return await base.AddToRoleAsync(user, role);
        }

        public override async Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            await GetByIdAsync(user.Id);
            return await base.AddToRolesAsync(user, roles);
        }
        public override async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
        {
            await GetByIdAsync(user.Id);
            return await base.ChangeEmailAsync(user, newEmail, token);
        }

        public override async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await base.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public override async Task<IdentityResult> ChangePhoneNumberAsync(User user, string phoneNumber, string token)
        {
            await GetByIdAsync(user.Id);
            return await base.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public override async Task<bool> CheckPasswordAsync(User user, string password)
        {
            await GetByIdAsync(user.Id);
            return await base.CheckPasswordAsync(user, password);
        }

        public override async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await base.ConfirmEmailAsync(user, token);
        }

        public override async Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.Status = Status.Active;
            return await base.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            user.Status = Status.Deleted;
            return await base.UpdateAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await base.FindByEmailAsync(email);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public async Task<User> GetByNameAsync(string userName)
        {
            var user = await base.FindByNameAsync(userName);
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public override async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await base.GenerateEmailConfirmationTokenAsync(user);
        }

        public override async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await base.GeneratePasswordResetTokenAsync(user);
        }

        public override async Task<User> FindByIdAsync(string id)
        {
            return await base.FindByIdAsync(id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await base.FindByIdAsync(id.ToString());
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException(nameof(User));
            return user;
        }

        public override async Task<bool> IsEmailConfirmedAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await base.IsEmailConfirmedAsync(user);
        }

        public override async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            await GetByIdAsync(user.Id);
            return await base.ResetPasswordAsync(user, token, newPassword);
        }

        public override async Task<IdentityResult> UpdateAsync(User user)
        {
            await GetByIdAsync(user.Id);
            return await base.UpdateAsync(user);
        }
    }
}