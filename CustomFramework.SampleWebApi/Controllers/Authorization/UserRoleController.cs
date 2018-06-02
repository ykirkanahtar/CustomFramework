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

    [Route(ApiConstants.AdminRoute + nameof(UserRole))]
    public class UserRoleController : BaseUserRoleController
    {

        public UserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<UserRoleController> logger, IMapper mapper)
            : base(userRoleManager, localizationService, logger, mapper)
        {

        }
    }
}
