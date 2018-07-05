using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using CustomFramework.Authorization.Attributes;

namespace CustomFramework.WebApiUtils.Authorization.Request
{
    public class HasPermissionRequest
    {
        public HasPermissionRequest(ClaimsPrincipal claimsPrincipal, int applicationId, IEnumerable<PermissionAttribute> permissionAttributes)
        {
            ClaimsPrincipal = claimsPrincipal;
            ApplicationId = applicationId;
            PermissionAttributes = permissionAttributes;
        }

        [Required]
        public ClaimsPrincipal ClaimsPrincipal { get; }

        [Required]
        public int ApplicationId { get; }

        [Required]
        public IEnumerable<PermissionAttribute> PermissionAttributes { get; }
    }
}
