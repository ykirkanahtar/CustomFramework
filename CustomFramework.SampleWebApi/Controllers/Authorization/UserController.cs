using AutoMapper;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Resources;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.AdminRoute + nameof(WebApiUtils.Authorization.Models.User))]
    public class UserController : BaseUserController
    {
        public UserController(IUserManager userManager, ILocalizationService localizationService, ILogger<UserController> logger, IMapper mapper)
            : base(userManager, localizationService, logger, mapper)
        {

        }
    }
}
