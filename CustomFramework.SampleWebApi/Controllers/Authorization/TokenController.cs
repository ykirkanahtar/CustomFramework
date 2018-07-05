using AutoMapper;
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
        public TokenController(IApplicationManager applicationManager, IApplicationUserManager applicationUserManager, IClientApplicationManager clientApplicationManager
            , IUserManager userManager, ILocalizationService localizationService, ILogger<TokenController> logger, IMapper mapper)
            : base(applicationManager, applicationUserManager, clientApplicationManager, userManager, localizationService, logger, mapper, Startup.AppSettings.Token)
        {

        }
    }
}