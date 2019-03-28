using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomUserManager<TUser> where TUser : CustomUser
    {
        Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims);
        Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login);
        Task<IdentityResult> AddPasswordAsync(TUser user, string password);
        Task<IdentityResult> AddToRoleAsync(TUser user, string role);
        Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles);
        Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token);
        Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);
        Task<IdentityResult> ConfirmEmailAsync(TUser user, string token);
        Task<IdentityResult> CreateAsync(TUser user, string password, Func<Task> func);
        Task<IdentityResult> DeleteAsync(int id);
        Task<TUser> FindByIdAsync(string id);
        Task<TUser> GetByEmailAsync(string email);
        Task<TUser> GetByNameAsync(string userName);
        Task<string> GenerateEmailConfirmationTokenAsync(TUser user);
        Task<string> GeneratePasswordResetTokenAsync(TUser user);
        Task<TUser> GetByIdAsync(int id);
        Task<bool> IsEmailConfirmedAsync(TUser user);
        Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles);
        Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
        Task<IdentityResult> UpdateAsync(TUser user);
        Task<List<TUser>> GetAllUsersAsync();
    }
}