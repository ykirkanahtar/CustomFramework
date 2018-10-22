using AutoMapper;
using CustomFramework.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BasePermissionController : BaseController
    {
        private readonly IPermissionManager _permissionManager;

        public BasePermissionController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IPermissionManager permissionManager) 
            : base(localizationService, logger, mapper)
        {
            _permissionManager = permissionManager;
        }

        [HttpPost]
        public Task<IActionResult> HasPermissionAsync([FromBody] HasPermissionRequest hasPermissionRequest)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                var hasPermission = await _permissionManager.HasPermission(hasPermissionRequest);

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(hasPermission));
            });
        }
    }
}