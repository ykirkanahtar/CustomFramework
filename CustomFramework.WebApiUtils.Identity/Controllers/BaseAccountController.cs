using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.EmailProvider;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Utils;
using CustomFramework.Utils;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using CustomFramework.WebApiUtils.Identity.Extensions;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Identity.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseAccountController<TUser, TUserRequest, TUserResponse, TRole> : BaseController
    where TUser : CustomUser
    where TUserRequest : CustomUserRegisterRequest
    where TUserResponse : CustomUserResponse
    where TRole : CustomRole
    {
        private readonly SignInManager<TUser> _signInManager;
        protected readonly ICustomUserManager<TUser> CustomUserManager;
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IEmailSender _emailSender;
        private readonly IdentityModel _identityModel;

        public BaseAccountController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, SignInManager<TUser> signInManager, ICustomUserManager<TUser> customUserManager, IClientApplicationManager clientApplicationManager, IEmailSender emailSender) : base(localizationService, logger, mapper)
        {
            _signInManager = signInManager;
            CustomUserManager = customUserManager;
            _clientApplicationManager = clientApplicationManager;
            _emailSender = emailSender;
            _identityModel = IdentityModelExtension<TUser, TRole>.IdentityConfig;
        }

        protected async Task<IActionResult> BaseRegisterAsync([FromBody] TUserRequest request, Func<Task> func, bool generatePassword = false)
        {
            if (generatePassword)
            {
                var passwordLength = _identityModel.GeneratedPasswordLength < 6 ? 6 : _identityModel.GeneratedPasswordLength;
                var passwordGenerated = Password.Generate(passwordLength, 1);
                request.Password = passwordGenerated;
                request.ConfirmPassword = passwordGenerated;
            }

            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var user = Mapper.Map<TUser>(request);
            user.UserName = user.Email;

            var result = await CustomUserManager.CreateAsync(user, request.Password, func);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
            }

            var text = string.Empty;
            if (generatePassword) text = $"Sistem tarafından oluşturulan yeni parolanız: {request.Password}";

            await ConfirmationEmailSenderAsync(user, $"{_identityModel.AppName} - Hesap Kaydınız", text, request.CallBackUrl);

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TUser, TUserResponse>(user)));
        }

        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);
            if (!result.Succeeded)
            {
                throw new AuthenticationException();
            }

            var user = await CustomUserManager.GetByEmailAsync(login.Email);
            if (user == null)
                throw new Exception("Unknown error");

            var clientApplication =
                await _clientApplicationManager.LoginAsync(login.ClientApplicationCode,
                    login.ClientApplicationPassword);

            var apiRequest = new ApiRequest(0, user.Id,
                clientApplication.Id);

            var tokenResponse = GenerateJwtToken(user.Id, apiRequest);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(tokenResponse));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("CheckService")]
        public IActionResult CheckService()
        {
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        protected async Task<IActionResult> BaseConfirmEmailAsync(ConfirmEmailRequest request)
        {
            if (request.UserId < 1 || request.Code == null)
            {
                throw new ArgumentException($"Hatalı bağlantı"); //Invalid link
            }

            var user = await CustomUserManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound($"Bu id değerine ait kullanıcı bulunamadı."); //Unable to load user with Id '{userId}'.
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await CustomUserManager.ConfirmEmailAsync(user, codeDecoded);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                throw new ArgumentException($"E-posta doğrulaması sırasında hata oluştu : {ModelState.ModelStateToString(LocalizationService)}"); //Error confirming email for user with ID '{userId}':
            }

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        protected async Task<IActionResult> BaseForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await CustomUserManager.GetByEmailAsync(request.EmailAddress);
            if (user == null)
            {
                throw new ArgumentException("Kullanıcı bulunamadı."); //User not found.
            }

            if (!await CustomUserManager.IsEmailConfirmedAsync(user))
            {
                throw new ArgumentException("Lütfen kaydınızı onaylayınız."); //Please confirm your registration.
            }

            // For more information on how to enable account confirmation and password reset please 
            // visit https://go.microsoft.com/fwlink/?LinkID=532713

            await ResetPasswordEmailSenderAsync(user, "Parola Yenileme", "Parolanızı yenilemek için lütfen bağlantıya tıklayınız", request.CallBackUrl);

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        protected async Task<IActionResult> BaseResetPasswordAsync(ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            if (request.Code == null)
            {
                throw new ArgumentException("Parola yenilemek için kod gerekmektedir."); //A code must be supplied for password reset.
            }

            var user = await CustomUserManager.GetByEmailAsync(request.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                throw new ArgumentException("Hatalı kullanıcı bilgisi."); //Invalid User
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await CustomUserManager.ResetPasswordAsync(user, codeDecoded, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
            }

            var receiverList = new List<string>();
            receiverList.Add(request.Email);

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, receiverList, $"{_identityModel.AppName} - Parolanız değiştirildi", $"Parolanız değiştirildi.Eğer bu işlemi siz yapmadıysanız lütfen site yöneticisi ile iletişim geçiniz.");

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        private async Task ResetPasswordEmailSenderAsync(TUser user, string title, string text, string callbackUrl = "")
        {
            var code = await CustomUserManager.GeneratePasswordResetTokenAsync(user);
            var codeBytes = Encoding.UTF8.GetBytes(code);
            var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

            var receiverList = new List<string>();
            receiverList.Add(user.Email);

            if (String.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = Url.Action(
                    action: "ResetPasswordAsync",
                    controller: "Account",
                    values : new { code = codeEncoded },
                    protocol : Request.Scheme);
            }
            else
            {
                callbackUrl = callbackUrl.Replace("ReplaceUserIdValue", user.Id.ToString());
                callbackUrl = callbackUrl.Replace("ReplaceCodeValue", codeEncoded);
            }

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, receiverList, $"{_identityModel.AppName} - {title}", $"{text}. - {callbackUrl} ya da kodu ilgili forma giriniz. {codeEncoded}"); //Please reset your password by clicking here
        }

        private string ConfirmationEmailUrlCreator(int userId, string codeEncoded, string emailText, string callbackUrl = "")
        {
            if (String.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = Url.Action(
                    action: "ConfirmEmailAsync",
                    controller: "Account",
                    values : new { userId = userId, code = codeEncoded },
                    protocol : Request.Scheme);

            }
            else
            {
                callbackUrl = callbackUrl.Replace("ReplaceUserIdValue", userId.ToString());
                callbackUrl = callbackUrl.Replace("ReplaceCodeValue", codeEncoded);
            }

            return $"{emailText} Hesabınızı onaylamak için lütfen bağlantıya tıklayınız - {callbackUrl}";
        }

        private async Task ConfirmationEmailSenderAsync(TUser user, string title, string text, string callbackUrl = "")
        {
            var code = await CustomUserManager.GenerateEmailConfirmationTokenAsync(user);
            var codeBytes = Encoding.UTF8.GetBytes(code);
            var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

            var receiverList = new List<string>();
            receiverList.Add(user.Email);

            var emailBody = string.Empty;

            if (_identityModel.EmailConfirmationViaUrl) emailBody = $"{text} ConfirmationEmailUrlCreator(user.Id, codeEncoded, text, callbackUrl)";
            else emailBody = $"{text} Hesap onay kodunuz : {codeEncoded}";

            await _emailSender.SendEmailAsync(
                _identityModel.SenderEmailAddress, receiverList, $"{_identityModel.AppName} - {title}", $"{emailBody}");
        }

        private TokenResponse GenerateJwtToken(int userId, IApiRequest apiRequest)
        {
            var apiRequestJson = JsonConvert.SerializeObject(apiRequest,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.All,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(typeof(IApiRequest).Name, apiRequestJson),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = _identityModel.Token.Key;
            var issuer = _identityModel.Token.Issuer;
            var audience = _identityModel.Token.Audience;
            var expireInMinutes = _identityModel.Token.ExpireInMinutes;

            var token = JwtManager.GenerateToken(claims, key, issuer, audience, out var expireDateTime,
                expireInMinutes);

            return new TokenResponse
            {
                Token = token,
                    ExpireInMinutes = expireInMinutes,
                    RequestUtcDateTime = DateTime.UtcNow,
                    ExpireUtcDateTime = expireDateTime,
            };
        }

    }

}