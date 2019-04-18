using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomUserManager<TUser>
        where TUser : CustomUser
        {
            Task<IdentityResult> AddClaimAsync(int id, Claim claim, IList<Claim> existingClaims);
            Task<IList<Claim>> AddClaimsAsync(int id, IEnumerable<Claim> claims, IList<Claim> existingClaims);
            Task<IdentityResult> AddToRoleAsync(int id, string role);
            Task<IdentityResult> AddToRolesAsync(int id, IEnumerable<string> roles);
            Task<IdentityResult> ChangeEmailAsync(int id, string newEmail, string token);
            Task<IdentityResult> ChangePasswordAsync(int id, string currentPassword, string newPassword);
            Task<IdentityResult> ConfirmEmailAsync(TUser user, string token);
            Task<IdentityResult> CreateAsync(TUser user, string password, Func<Task> func);
            Task<IdentityResult> DeleteAsync(int id);
            Task<TUser> FindByIdAsync(string id);
            Task<TUser> GetByEmailAsync(string email);
            Task<TUser> GetByNameAsync(string userName);
            Task<IList<Claim>> GetUserClaimsAsync(int id);
            Task<IList<Claim>> GetAllClaimsForLoggedUserAsync();
            Task<IList<TUser>> GetUsersInRoleAsync(string roleName);
            Task<IList<string>> GetRolesAsync(int id);
            Task<string> GenerateEmailConfirmationTokenAsync(TUser user);
            Task<string> GeneratePasswordResetTokenAsync(TUser user);
            Task<IList<TUser>> GetAllAsync();
            Task<TUser> GetByIdAsync(int id);
            Task<bool> IsEmailConfirmedAsync(TUser user);
            Task<IdentityResult> RemoveClaimAsync(int id, Claim claim);
            Task<IdentityResult> RemoveFromRoleAsync(int id, string role);
            Task<IdentityResult> RemoveFromRolesAsync(int id, IEnumerable<string> roles);
            Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);
            Task<IdentityResult> UpdateAsync(TUser user);
        }
}