using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.EmailProvider;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Utils;
using CustomFramework.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Extensions;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Identity.Utils;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
        private readonly IIdentityModel _identityModel;
        private readonly IEmailSender _emailSender;

        public CustomUserManager(UserManager<TUser> userManager, ICustomRoleManager<TRole> roleManager, IIdentityModel identityModel, IEmailSender emailSender, ILogger<CustomRoleManager<TUser, TRole>> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(logger, mapper, httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _identityModel = identityModel;
            _emailSender = emailSender;
        }

        public async Task<IdentityResult> RegisterAsync(TUser user, string password, Func<Task> func)
        {
            return await CreateAsync(user, password, func);
        }

        public async Task<IdentityResult> RegisterAsync(TUser user, string password, Func<Task> func, List<string> roles)
        {
            var result = await RegisterAsync(user, password, func);
            if (!result.Succeeded) return result;

            var addToRoleResult = await AddToRolesAsync(user.Id, roles);
            if (!result.Succeeded) return result;

            return result;
        }

        public async Task<IdentityResult> RegisterWithGeneratedPasswordAsync(TUser user, string password, Func<Task> func, List<string> roles, int generatePasswordLength)
        {
            var passwordLength = generatePasswordLength < 6 ? 6 : (int) generatePasswordLength;
            var passwordGenerated = Password.Generate(passwordLength, 1);
            password = passwordGenerated;

            return await RegisterAsync(user, password, func, roles);
        }

        public async Task<IdentityResult> RegisterWithConfirmationEmailAsync(TUser user, string password, Func<Task> func, List<string> roles, IUrlHelper url, string emailTitle, string emailBody, string requestScheme, string callbackUrl)
        {
            var result = await RegisterAsync(user, password, func, roles);
            if (!result.Succeeded) return result;

            await ConfirmationEmailSenderAsync(user, emailTitle, emailBody, url, callbackUrl);

            return result;
        }

        public async Task<IdentityResult> RegisterWithConfirmationAndGeneratedPasswordAsync(TUser user, string password, Func<Task> func, List<string> roles, int generatePasswordLength, IUrlHelper url, string emailTitle, string emailBody, string requestScheme, string callbackUrl)
        {
            var result = await RegisterWithGeneratedPasswordAsync(user, password, func, roles, generatePasswordLength);
            if (!result.Succeeded) return result;

            emailBody += $"Sistem tarafından oluşturulan yeni parolanız: {password}";

            await ConfirmationEmailSenderAsync(user, emailTitle, emailBody, url, callbackUrl);

            return result;
        }

        public async Task<IdentityResult> ChangePasswordWithEmailAsync(string email, string oldPassword, string newPassword, string confirmPassword)
        {
            var user = await GetByEmailAsync(email);
            if (user == null)
            {
                throw new KeyNotFoundException($"Kullanıcı bulunamadı.");
            }

            return await BaseChangePasswordAsync(user, oldPassword, newPassword, confirmPassword);
        }

        public async Task<IdentityResult> ChangePasswordWithUserNameAsync(string userName, string oldPassword, string newPassword, string confirmPassword)
        {
            var user = await GetByUserNameAsync(userName);
            if (user == null)
            {
                throw new KeyNotFoundException($"Kullanıcı bulunamadı.");
            }

            return await BaseChangePasswordAsync(user, oldPassword, newPassword, confirmPassword);
        }

        private async Task<IdentityResult> BaseChangePasswordAsync(TUser user, string oldPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                throw new ArgumentException($"Yeni parola ile onay parolası uyumsuz");
            }

            if (oldPassword == newPassword)
            {
                throw new ArgumentException($"Eski parola yeni parola ile aynı olamaz.");
            }

            return await ChangePasswordAsync(user.Id, oldPassword, newPassword);
        }

        public async Task<IdentityResult> AddClaimAsync(int id, Claim claim, IList<Claim> existingClaims)
        {
            var user = await GetByIdAsync(id);
            var claims = await GetUserClaimsAsync(user.Id);

            ClaimChecker.CheckClaimStatus(claim, claims, existingClaims);

            return await _userManager.AddClaimAsync(user, claim);
        }

        public async Task<IList<Claim>> AddClaimsAsync(int id, IEnumerable<Claim> claims, IList<Claim> existingClaims)
        {
            var addedClaims = new List<Claim>();
            var user = await GetByIdAsync(id);
            var userClaims = await GetUserClaimsAsync(user.Id);

            foreach (var claim in claims)
            {
                Claim checkedClaim;
                bool claimCheckSuccess = false;
                try
                {
                    //CheckClaimStaus metodu hata oluştuğunda Exception fırlatıyor.
                    //Fakat bu metotta claim değerleri bir dizi halinde olduğu için 
                    //Başarısız işlemlerde hata üretilmesini değil, diziye eklenmemesini istiyoruz
                    //Bu yüzden boş bir try catch bloğu içerisine alındı
                    checkedClaim = ClaimChecker.CheckClaimStatus(claim, userClaims, existingClaims);
                    claimCheckSuccess = true;
                }
                catch (KeyNotFoundException)
                {
                    throw new KeyNotFoundException(nameof(Claim));
                }
                catch { }

                if (claimCheckSuccess)
                {
                    await _userManager.AddClaimAsync(user, claim);
                    addedClaims.Add(claim);
                }
            }

            return addedClaims;
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

        public async Task<IdentityResult> ConfirmEmailAsync(int id, string token)
        {
            var user = await GetByIdAsync(id);

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            return await _userManager.ConfirmEmailAsync(user, codeDecoded);
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

        public async Task<TUser> GetByUserNameAsync(string userName)
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

        public async Task ForgotPasswordAsync(string emailAddress, string emailTitle, string emailText, IUrlHelper url, string requestScheme, string callbackUrl)
        {
            var user = await GetByEmailAsync(emailAddress);

            if (!await IsEmailConfirmedAsync(user))
            {
                throw new ArgumentException("Lütfen kaydınızı onaylayınız."); //Please confirm your registration.
            }

            // For more information on how to enable account confirmation and password reset please 
            // visit https://go.microsoft.com/fwlink/?LinkID=532713

            await ResetPasswordEmailSenderAsync(user, emailTitle, emailText, url, requestScheme, callbackUrl);
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

        public async Task<IdentityResult> ResetPasswordAsync(int id, string token, string newPassword)
        {
            var user = await GetByIdAsync(id);
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string emailAddress, string token, string newPassword, string confirmPassword, string emailTitle, string emailText)
        {
            if (token == null)
            {
                throw new ArgumentException("Parola yenilemek için kod gerekmektedir."); //A code must be supplied for password reset.
            }

            if (newPassword != confirmPassword)
            {
                throw new ArgumentException($"Yeni parola ile onay parolası uyumsuz");
            }

            var user = await GetByEmailAsync(emailAddress);

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded) return result;

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, new List<string> { emailAddress }, emailTitle, emailText);

            return result;
        }

        public async Task<IdentityResult> UpdateAsync(TUser user)
        {
            await GetByIdAsync(user.Id);
            return await _userManager.UpdateAsync(user);
        }

        private async Task ConfirmationEmailSenderAsync(TUser user, string title, string text, IUrlHelper url, string requestScheme, string callbackUrl = "")
        {
            var code = await GenerateEmailConfirmationTokenAsync(user);
            var codeBytes = Encoding.UTF8.GetBytes(code);
            var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

            var receiverList = new List<string>();
            receiverList.Add(user.Email);

            var emailBody = string.Empty;

            if (_identityModel.EmailConfirmationViaUrl) emailBody = $"{ConfirmationEmailUrlCreator(user.Id, codeEncoded, text,url, requestScheme, callbackUrl)}";
            else emailBody = $"{text} Hesap onay kodunuz : {codeEncoded}";

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, receiverList, $"{_identityModel.AppName} - {title}", $"{emailBody}");
        }

        private string ConfirmationEmailUrlCreator(int userId, string codeEncoded, string emailText, IUrlHelper url, string requestScheme, string callbackUrl = "")
        {
            if (String.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = url.Action(
                    action: "ConfirmEmailAsync",
                    controller: "Account",
                    values : new { userId = userId, code = codeEncoded },
                    protocol : requestScheme);

            }
            else
            {
                callbackUrl = callbackUrl.Replace("ReplaceUserIdValue", userId.ToString());
                callbackUrl = callbackUrl.Replace("ReplaceCodeValue", codeEncoded);
            }

            return $"{emailText} Hesabınızı onaylamak için lütfen bağlantıya tıklayınız - {callbackUrl}";
        }

        private async Task ResetPasswordEmailSenderAsync(TUser user, string title, string text, IUrlHelper url, string requestScheme, string callbackUrl = "")
        {
            var code = await GeneratePasswordResetTokenAsync(user);
            var codeBytes = Encoding.UTF8.GetBytes(code);
            var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

            var receiverList = new List<string>();
            receiverList.Add(user.Email);

            if (String.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = url.Action(
                    action: "ResetPasswordAsync",
                    controller: "Account",
                    values : new { code = codeEncoded },
                    protocol : requestScheme);
            }
            else
            {
                callbackUrl = callbackUrl.Replace("ReplaceUserIdValue", user.Id.ToString());
                callbackUrl = callbackUrl.Replace("ReplaceCodeValue", codeEncoded);
            }

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, receiverList, $"{_identityModel.AppName} - {title}", $"{text}. - {callbackUrl} ya da kodu ilgili forma giriniz. {codeEncoded}"); //Please reset your password by clicking here
        }

    }
}