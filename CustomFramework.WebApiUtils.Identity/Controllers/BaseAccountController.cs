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
    public class BaseAccountController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomUserManager _userManager;
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IEmailSender _emailSender;
        private readonly IToken _token;

        public BaseAccountController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, SignInManager<User> signInManager, ICustomUserManager userManager, IClientApplicationManager clientApplicationManager, IToken token, IEmailSender emailSender) : base(localizationService, logger, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _clientApplicationManager = clientApplicationManager;
            _token = token;
            _emailSender = emailSender;
        }

        protected async Task<IActionResult> BaseRegisterAsync([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

            var user = Mapper.Map<User>(request);
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
            }

            await ConfirmationEmailSenderAsync(user, "Confirm Your Account", "Please confirm your email by clicking here", request.CallBackUrl);

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(user)));
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

            var user = await _userManager.GetByEmailAsync(login.Email);
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

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return NotFound($"Bu id değerine ait kullanıcı bulunamadı."); //Unable to load user with Id '{userId}'.
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);
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
            var user = await _userManager.GetByEmailAsync(request.EmailAddress);
            if (user == null)
            {
                throw new ArgumentException("Kullanıcı bulunamadı."); //User not found.
            }

            if (IdentityModelExtension.IdentityConfig.SendConfirmationEmail)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    throw new ArgumentException("Lütfen kaydınızı onaylayınız."); //Please confirm your registration.
                }
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

            var user = await _userManager.GetByEmailAsync(request.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                throw new ArgumentException("Hatalı kullanıcı bilgisi."); //Invalid User
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await _userManager.ResetPasswordAsync(user, codeDecoded, request.Password);
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
                IdentityModelExtension.IdentityConfig.SenderEmailAddress, receiverList, $"{IdentityModelExtension.IdentityConfig.AppName} - Parolanız değiştirildi", $"Parolanız değiştirildi.Eğer bu işlemi siz yapmadıysanız lütfen site yöneticisi ile iletişim geçiniz.");

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        private async Task ResetPasswordEmailSenderAsync(User user, string title, string text, string callbackUrl = "")
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
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
                IdentityModelExtension.IdentityConfig.SenderEmailAddress, receiverList, $"{IdentityModelExtension.IdentityConfig.AppName} - {title}", $"{text}. - {callbackUrl} ya da kodu ilgili forma giriniz. {codeEncoded}"); //Please reset your password by clicking here
        }

        private async Task ConfirmationEmailSenderAsync(User user, string title, string text, string callbackUrl = "")
        {
            if (IdentityModelExtension.IdentityConfig.SendConfirmationEmail)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var codeBytes = Encoding.UTF8.GetBytes(code);
                var codeEncoded = WebEncoders.Base64UrlEncode(codeBytes);

                var receiverList = new List<string>();
                receiverList.Add(user.Email);

                if (String.IsNullOrEmpty(callbackUrl))
                {
                    callbackUrl = Url.Action(
                        action: "ConfirmEmailAsync",
                        controller: "Account",
                        values : new { userId = user.Id, code = codeEncoded },
                        protocol : Request.Scheme);

                }
                else
                {
                    callbackUrl = callbackUrl.Replace("ReplaceUserIdValue", user.Id.ToString());
                    callbackUrl = callbackUrl.Replace("ReplaceCodeValue", codeEncoded);
                }

                await _emailSender.SendEmailAsync(
                    IdentityModelExtension.IdentityConfig.SenderEmailAddress, receiverList, $"{IdentityModelExtension.IdentityConfig.AppName} - {title}", $"{text}. - {callbackUrl}");
            }
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

            var key = _token.Key;
            var issuer = _token.Issuer;
            var audience = _token.Audience;
            var expireInMinutes = _token.ExpireInMinutes;

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