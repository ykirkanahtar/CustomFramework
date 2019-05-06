using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Handlers;
using CustomFramework.WebApiUtils.Identity.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Identity.Handlers
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

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement, IEnumerable<PermissionAttribute> attributes)
        {
            await _permissionManager.HasPermission(attributes);
            context.Succeed(requirement);
        }
    }
}