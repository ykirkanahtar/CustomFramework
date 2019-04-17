using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Business;
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
    public class CustomUserManager<TUser, TRole> : BaseBusinessManager, ICustomUserManager<TUser>
        where TUser : CustomUser
    where TRole : CustomRole
    {
        private readonly UserManager<TUser> _userManager;
        private readonly ICustomRoleManager<TRole> _roleManager;

        public CustomUserManager(UserManager<TUser> userManager, ICustomRoleManager<TRole> roleManager, ILogger<CustomRoleManager<TUser, TRole>> logger, IMapper mapper) : base(logger, mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddClaimAsync(int id, Claim claim)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.AddClaimAsync(user, claim);
        }

        public async Task<IdentityResult> AddClaimsAsync(int id, IEnumerable<Claim> claims)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.AddClaimsAsync(user, claims);
        }

        public async Task<IdentityResult> AddToRoleAsync(int id, string role)
        {
            var user = await GetByIdAsync(id);
            await _roleManager.GetByNameAsync(role);
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddToRolesAsync(int id, IEnumerable<string> roles)
        {
            var user = await GetByIdAsync(id);
            foreach (var role in roles)
            {
                await _roleManager.GetByNameAsync(role);
            }
            return await _userManager.AddToRolesAsync(user, roles);
        }
        public async Task<IdentityResult> ChangeEmailAsync(int id, string newEmail, string token)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<IdentityResult> ChangePasswordAsync(int id, string currentPassword, string newPassword)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<bool> CheckPasswordAsync(int id, string password)
        {
            var user = await GetByIdAsync(id);
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

            var roles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, roles);

            (await GetRolesAsync(id)).CheckSubFieldIsExistForDelete("Role");

            var uniqueValue = DateTime.UtcNow.ToString();
            var emailValue = $"deleted_{uniqueValue}_{user.Email}";
            var userNameValue = $"{DateTime.UtcNow.ToString("yyMMdd")}_{Guid.NewGuid().ToString().Substring(0, 6)}";

            user.Email = emailValue; //Identity'de silinen bir veriye ait unique alan tekrar kaydedilmek istendiğinde duplicate key hatası veriyordu. Buna önlem olarak silinen kaydın unique key alanına unique değerler getirildi
            user.NormalizedEmail = emailValue.ToUpper();

            user.UserName = userNameValue; //user.Email ile aynı değeri alınca hata vermiyor fakat entity'i de güncellemiyordu. Bu yüzden kısa bir değer seçildi

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

        public async Task<IList<TUser>> GetAllAsync()
        {
            return await _userManager.Users.AsQueryable().Where(p => p.Status == Status.Active).OrderBy(p => p.FirstName).ToListAsync();
        }

        public async Task<TUser> GetByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null || user.Status != Status.Active) throw new KeyNotFoundException("User");
            return user;
        }

        public async Task<IList<Claim>> GetUserClaimsAsync(int id)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.GetClaimsAsync(user);
        }

        public async Task<IList<Claim>> GetAllClaimsForLoggedUserAsync()
        {
            var userId = GetUserId();
            var userClaims = await GetUserClaimsAsync(userId);
            var claims = userClaims;

            var roles = await GetRolesAsync(userId);
            foreach (var role in roles)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    //UserClaim RoleClaiim'i ezdiği için öncelikle UserClaim'de yetki var mı diye kontrol ediliyor.
                    var claimIsExistInUserClaims = (from p in userClaims where p.Type == roleClaim.Type select p).Count() > 0;
                    
                    if (!claimIsExistInUserClaims)
                    {
                        //Çift kaydı engellemek için ClaimType ve ClaimValue değerleri eşleşen kayıtlar eklenmiyor.
                        var claimIsExistInClaims = (from p in claims where p.Type == roleClaim.Type && p.Value == roleClaim.Value select p).Count() > 0;

                        if (!claimIsExistInClaims)
                            claims.Add(roleClaim);
                    }
                }
            }

            return claims;
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

        public async Task<IdentityResult> RemoveClaimAsync(int id, Claim claim)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.RemoveClaimAsync(user, claim);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(int id, string role)
        {
            var user = await GetByIdAsync(id);
            await _roleManager.GetByNameAsync(role);
            return await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveFromRolesAsync(int id, IEnumerable<string> roles)
        {
            var user = await GetByIdAsync(id);
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
    }
}