using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Constants;
using Microsoft.AspNetCore.Authorization;
using ApiRequest = CustomFramework.WebApiUtils.Authorization.Contracts.ApiRequest;
using IApiRequest = CustomFramework.WebApiUtils.Authorization.Contracts.IApiRequest;
using IApiRequestAccessor = CustomFramework.WebApiUtils.Authorization.Utils.IApiRequestAccessor;

namespace CustomFramework.WebApiUtils.Authorization.Handlers
{
    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        private readonly IApiRequest _apiRequest;
        private readonly IUserRoleManager _userRoleManager;
        private readonly IClaimManager _claimManager;

        private readonly IRoleClaimManager _roleClaimManager;
        private readonly IUserClaimManager _userClaimManager;

        private readonly IRoleEntityClaimManager _roleEntityClaimManager;
        private readonly IUserEntityClaimManager _userEntityClaimManager;

        public PermissionAuthorizationHandler(IApiRequestAccessor apiRequestAccessor, IUserRoleManager userRoleManager, IClaimManager claimManager, IRoleClaimManager roleClaimManager, IUserClaimManager userClaimManager, IRoleEntityClaimManager roleEntityClaimManager, IUserEntityClaimManager userEntityClaimManager)
        {
            _apiRequest = apiRequestAccessor.GetApiRequest<ApiRequest>();
            _userRoleManager = userRoleManager;
            _claimManager = claimManager;
            _roleClaimManager = roleClaimManager;
            _userClaimManager = userClaimManager;
            _roleEntityClaimManager = roleEntityClaimManager;
            _userEntityClaimManager = userEntityClaimManager;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context
                                                            , PermissionAuthorizationRequirement requirement
                                                            , IEnumerable<PermissionAttribute> attributes)
        {
            var claimsPrincipal = context.User;

            UserIsAuthenticated(claimsPrincipal);

            try
            {
                var userId = _apiRequest.User.Id;
                var roles = (await _userRoleManager.GetRolesByUserIdAsync(userId)).ResultList;

                foreach (var permissionAttribute in attributes)
                {
                    if (permissionAttribute.CustomClaim != null)
                    {
                        await CheckCustomClaimAsync(userId, roles, permissionAttribute.CustomClaim);
                    }
                    else if (permissionAttribute.Entity != null && permissionAttribute.Crud != null)
                    {
                        await CheckEntityClaimAsync(userId, roles, permissionAttribute.Entity, (Crud)permissionAttribute.Crud);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new UnauthorizedAccessException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            context.Succeed(requirement);
        }

        private static void UserIsAuthenticated(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || claimsPrincipal.Identity.IsAuthenticated == false)
            {
                throw new UnauthorizedAccessException(DefaultResponseMessages.UnauthorizedAccessError);
            }
        }

        private async Task CheckCustomClaimAsync(int userId, IList<Role> roles, string customClaim)
        {
            var claim = await _claimManager.GetByCustomClaimAsync(customClaim);
            await AuthorizeWithCustomClaimAsync(userId, roles, claim.Id);
        }

        private async Task CheckEntityClaimAsync(int userId, IList<Role> roles, string entity, Crud crud)
        {
            await AuthorizeWithEntityClaimAsync(userId, roles, entity, crud);
        }

        private async Task AuthorizeWithCustomClaimAsync(int userId, IList<Role> roles, int claimId)
        {
            var userIsAuthorized = await _userClaimManager.UserIsAuthorizedForClaimAsync(userId, claimId);
            var roleIsAuthorized = await _roleClaimManager.RolesAreAuthorizedForClaimAsync(roles, claimId);
            if (userIsAuthorized || roleIsAuthorized)
            {
                return;
            }

            throw new KeyNotFoundException();
        }

        private async Task AuthorizeWithEntityClaimAsync(int userId, IList<Role> roles, string entity, Crud crud)
        {
            var userIsAuthorized = await _userEntityClaimManager.UserIsAuthorizedForEntityClaimAsync(userId, entity, crud);
            var roleIsAuthorized = await _roleEntityClaimManager.RolesAreAuthorizedForEntityClaimAsync(roles, entity, crud);

            if (userIsAuthorized || roleIsAuthorized)
            {
                return;
            }

            throw new KeyNotFoundException();
        }

    }
}