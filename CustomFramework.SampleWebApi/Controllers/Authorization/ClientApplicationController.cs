using AutoMapper;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Resources;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.AdminRoute + nameof(ClientApplication))]
    public class ClientApplicationController : BaseClientApplicationController
    {
        public ClientApplicationController(IClientApplicationManager clientApplicationManager, ILocalizationService localizationService, ILogger<ClientApplicationController> logger, IMapper mapper)
            : base(clientApplicationManager, localizationService, logger, mapper)
        {

        }
    }
}
