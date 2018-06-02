using AutoMapper;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.AdminRoute + nameof(UserClaim))]
    public class UserClaimController : BaseUserClaimController
    {

        public UserClaimController(IUserClaimManager userClaimManager, ILocalizationService localizationService, ILogger<UserClaimController> logger, IMapper mapper)
            : base(userClaimManager, localizationService, logger, mapper)
        {

        }

    }
}
