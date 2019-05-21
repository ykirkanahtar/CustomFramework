using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomUserManager<TUser>
        where TUser : CustomUser
    {
        Task<IdentityResult> RegisterAsync(TUser user, string password, Func<Task> func = null);
        Task<IdentityResult> RegisterAsync(TUser user, string password, List<string> roles, Func<Task> func = null);
        Task<IdentityResult> RegisterWithGeneratedPasswordAsync(TUser user, string password, List<string> roles, int generatePasswordLength, Func<Task> func = null);
        Task<IdentityResult> RegisterWithConfirmationEmailAsync(TUser user, string password, List<string> roles, IUrlHelper url, string emailTitle, string emailBody, string requestScheme, string callbackUrl = null, Func<Task> func = null);
        Task<IdentityResult> RegisterWithConfirmationAndGeneratedPasswordAsync(TUser user, string password, List<string> roles, int generatePasswordLength, IUrlHelper url, string emailTitle, string emailBody, string requestScheme, Func<Task> func = null);
        Task<IdentityResult> ChangePasswordWithEmailAsync(string email, string oldPassword, string newPassword, string confirmPassword);
        Task<IdentityResult> ChangePasswordWithUserNameAsync(string userName, string oldPassword, string newPassword, string confirmPassword);
        Task<IdentityResult> AddClaimAsync(int id, Claim claim, IList<Claim> existingClaims);
        Task<IList<Claim>> AddClaimsAsync(int id, IEnumerable<Claim> claims, IList<Claim> existingClaims);
        Task<IdentityResult> AddToRoleAsync(int id, string role);
        Task<IdentityResult> AddToRolesAsync(int id, IEnumerable<string> roles);
        Task<IdentityResult> ChangeEmailAsync(int id, string newEmail, string token);
        Task<IdentityResult> ChangePasswordAsync(int id, string currentPassword, string newPassword);
        Task<IdentityResult> ConfirmEmailAsync(int id, string token);
        Task<IdentityResult> CreateAsync(TUser user, string password, Func<Task> func = null);
        Task<IdentityResult> DeleteAsync(int id, Func<Task> deleteCheck = null);
        Task<TUser> FindByIdAsync(string id);
        Task ForgotPasswordAsync(string emailAddress, string emailTitle, string emailText, IUrlHelper urlHelper, string requestScheme);
        Task<TUser> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<TUser> GetByEmailAsync(string email);
        Task<TUser> GetByUserNameAsync(string userName);
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
        Task<IdentityResult> ResetPasswordAsync(int id, string token, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(string emailAddress, string token, string newPassword, string confirmPassword, string emailTitle, string emailText);
        Task<IdentityResult> UpdateAsync(TUser user);
    }
}