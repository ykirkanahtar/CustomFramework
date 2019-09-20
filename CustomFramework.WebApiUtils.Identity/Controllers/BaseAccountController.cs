using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using CustomFramework.WebApiUtils.Identity.Extensions;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Contracts.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Identity.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseAccountController<TUser, TRole, TContext> : BaseController
    where TUser : CustomUser
    where TRole : CustomRole
    where TContext : DbContext
    {
        private readonly IdentityModel _identityModel;

        public BaseAccountController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper) : base(localizationService, logger, mapper)
        {
            _identityModel = IdentityModelExtension<TUser, TRole, TContext>.IdentityConfig;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("CheckService")]
        public IActionResult CheckService()
        {
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
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

            if (additionalClaims != null) claims.AddRange(additionalClaims);

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