using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + "token")]
    public class TokenController : BaseTokenController
    {
        public TokenController(IClientApplicationManager clientApplicationManager, IUserManager userManager, ILocalizationService localizationService, ILogger<TokenController> logger)
            : base(clientApplicationManager, userManager, localizationService, logger, Startup.AppSettings.Token)
        {

        }
    }
}