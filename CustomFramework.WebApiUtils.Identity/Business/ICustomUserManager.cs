using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomFramework.WebApiUtils.Identity.Business
{
    public interface ICustomUserManager
    {
        Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims);
        Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login);
        Task<IdentityResult> AddPasswordAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles);
        Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> DeleteAsync(int id);
        Task<User> FindByIdAsync(string id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNameAsync(string userName);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
        Task<IdentityResult> UpdateAsync(User user);
        Task<List<User>> GetAllUsersAsync();
    }
}