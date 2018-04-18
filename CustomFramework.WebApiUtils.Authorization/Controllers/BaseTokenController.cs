using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Authorization;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseTokenController : Controller
    {
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly IUserManager _userManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseTokenController> _logger;
        private readonly IToken _token;

        public BaseTokenController(IClientApplicationManager clientApplicationManager, IUserManager userManager, ILocalizationService localizationService, ILogger<BaseTokenController> logger, IToken token)
        {
            _clientApplicationManager = clientApplicationManager;
            _userManager = userManager;
            _localizationService = localizationService;
            _logger = logger;
            _token = token;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString());

            var clientApplication =
                await _clientApplicationManager.LoginAsync(login.ClientApplicationCode, login.ClientApplicationPassword);

            var user = await _userManager.LoginAsync(login.UserName, login.UserPassword);

            var apiRequest = new ApiRequest(user, clientApplication);

            var claims = new List<Claim>
            {
                new Claim(typeof(IApiRequest).Name, JsonConvert.SerializeObject(apiRequest)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = _token.Key;
            var issuer = _token.Issuer;
            var audience = _token.Audience;
            var expireInMinutes = _token.ExpireInMinutes;
            var token = JwtManager.GenerateToken(claims, key, issuer, audience, out var expireDateTime, expireInMinutes);

            var tokenResponse = new TokenResponse
            {
                Token = token,
                ExpireInMinutes = expireInMinutes,
                RequestUtcDateTime = DateTime.UtcNow,
                ExpireUtcDateTime = expireDateTime,
            };

            return Ok(new ApiResponse(_localizationService, _logger).Ok(tokenResponse));
        }
    }
}