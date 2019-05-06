using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Transactions;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("CheckService")]
        public IActionResult CheckService()
        {
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [NonAction]
        protected async Task<IActionResult> BaseGetAllClaimsForLoggedUserAsync()
        {
            var result = await CommonOperationAsync<IList<Claim>>(async() =>
            {
                return await CustomUserManager.GetAllClaimsForLoggedUserAsync();
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result)));
        }

        [NonAction]
        public TokenResponse GenerateJwtToken(int userId, IApiRequest apiRequest, List<Claim> additionalClaims = null)
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

            if(additionalClaims != null) claims.AddRange(additionalClaims);

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
                    UserId = userId
            };
        }

    }

}