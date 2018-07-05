using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            await _permissionManager.HasPermission(new HasPermissionRequest(
                context.User,
                Convert.ToInt32(ConfigHelper.GetConfigurationValue("ApplicationId")),
                attributes
            ));

            context.Succeed(requirement);
        }
    }
}