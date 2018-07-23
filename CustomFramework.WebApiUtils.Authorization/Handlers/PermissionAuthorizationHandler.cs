using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Authorization.Handlers
{
    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        private readonly ILogger<PermissionAuthorizationHandler> _logger;
        private readonly IPermissionManager _permissionManager;

        public PermissionAuthorizationHandler(ILogger<PermissionAuthorizationHandler> logger, IPermissionManager permissionManager)
        {
            _logger = logger;
            _permissionManager = permissionManager;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context
                                                            , PermissionAuthorizationRequirement requirement
                                                            , IEnumerable<PermissionAttribute> attributes)
        {
            UserIsAuthenticated(context.User);

            await _permissionManager.HasPermission(new HasPermissionRequest(
                Convert.ToInt32(ConfigHelper.GetConfigurationValue("ApplicationId")),
                attributes
            ));

            context.Succeed(requirement);
        }

        private static void UserIsAuthenticated(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null) throw new ArgumentNullException(nameof(claimsPrincipal));
            if (claimsPrincipal == null || !claimsPrincipal.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException(DefaultResponseMessages.UnauthorizedAccessError);
            }
        }
    }
}