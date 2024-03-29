﻿using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Contracts.Responses;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseTokenController : BaseController
    {
        private readonly IApplicationManager _applicationManager;
        private readonly IApplicationUserManager _applicationUserManager;
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IUserManager _userManager;
        private readonly IToken _token;

        public BaseTokenController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IApplicationManager applicationManager, IApplicationUserManager applicationUserManager, IClientApplicationManager clientApplicationManager, IUserManager userManager, IToken token)
            : base(localizationService, logger, mapper)
        {
            _applicationManager = applicationManager;
            _applicationUserManager = applicationUserManager;
            _clientApplicationManager = clientApplicationManager;
            _userManager = userManager;
            _token = token;
        }

        [AllowAnonymous]
        [HttpPost]
        public Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                var application = await _applicationManager.GetByIdAsync(login.ApplicationId);

                var clientApplication =
                    await _clientApplicationManager.LoginAsync(login.ClientApplicationCode,
                        login.ClientApplicationPassword);

                var user = await _userManager.LoginAsync(login.Email, login.UserPassword);

                await _applicationUserManager.GetByApplicationIdAndUserIdAsync(application.Id, user.Id);

                var apiRequest = new ApiRequest(login.ApplicationId, user.Id, clientApplication.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(typeof(IApiRequest).Name, JsonConvert.SerializeObject(apiRequest,
                            new JsonSerializerSettings
                            {
                                PreserveReferencesHandling = PreserveReferencesHandling.All,
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }
                        )
                    ),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var key = _token.Key;
                var issuer = _token.Issuer;
                var audience = _token.Audience;
                var expireInMinutes = _token.ExpireInMinutes;
                var token = JwtManager.GenerateToken(claims, key, issuer, audience, out var expireDateTime,
                    expireInMinutes);

                var tokenResponse = new TokenResponse
                {
                    Token = token,
                    ExpireInMinutes = expireInMinutes,
                    RequestUtcDateTime = DateTime.UtcNow,
                    ExpireUtcDateTime = expireDateTime,
                };

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(tokenResponse));
            });
        }
    }
}