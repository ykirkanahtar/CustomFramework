using CustomFramework.Authorization.Enums;
using CustomFramework.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class PermissionManager : IPermissionManager
    {
        private readonly ILogger<PermissionAuthorizationHandler> _logger;
        private readonly IApiRequest _apiRequest;
        private readonly IUserRoleManager _userRoleManager;
        private readonly IClaimManager _claimManager;

        private readonly IRoleClaimManager _roleClaimManager;
        private readonly IUserClaimManager _userClaimManager;

        private readonly IRoleEntityClaimManager _roleEntityClaimManager;
        private readonly IUserEntityClaimManager _userEntityClaimManager;

        public PermissionManager(ILogger<PermissionAuthorizationHandler> logger, IApiRequestAccessor apiRequestAccessor, IUserRoleManager userRoleManager, IClaimManager claimManager, IRoleClaimManager roleClaimManager, IUserClaimManager userClaimManager, IRoleEntityClaimManager roleEntityClaimManager, IUserEntityClaimManager userEntityClaimManager)
        {
            _logger = logger;
            _apiRequest = apiRequestAccessor.GetApiRequest<ApiRequest>(); ;
            _userRoleManager = userRoleManager;
            _claimManager = claimManager;
            _roleClaimManager = roleClaimManager;
            _userClaimManager = userClaimManager;
            _roleEntityClaimManager = roleEntityClaimManager;
            _userEntityClaimManager = userEntityClaimManager;
        }

        public async Task<bool> HasPermission(HasPermissionRequest hasPermissionRequest)
        {
            try
            {
                var userId = _apiRequest.UserId;

                if (_apiRequest.ApplicationId != hasPermissionRequest.ApplicationId) throw new KeyNotFoundException("Uygulama id bulunamadı");

                var roles = (await _userRoleManager.GetRolesByUserIdAsync(userId)).ResultList;

                foreach (var permissionAttribute in hasPermissionRequest.PermissionAttributes)
                {
                    if (permissionAttribute.ClaimType != null)
                    {
                        await CheckCustomClaimAsync(hasPermissionRequest.ApplicationId, userId, roles, permissionAttribute.ClaimType);
                    }
                    else if (permissionAttribute.Entity != null && permissionAttribute.Crud != null)
                    {
                        await CheckEntityClaimAsync(_apiRequest.ApplicationId, userId, roles, permissionAttribute.Entity, (Crud)permissionAttribute.Crud);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                throw;
            }

            return true;
        }

        private async Task CheckCustomClaimAsync(int applicationId, int userId, IList<Role> roles, string customClaim)
        {
            var claim = await _claimManager.GetByCustomClaimAsync(customClaim);
            await AuthorizeWithCustomClaimAsync(applicationId, userId, roles, claim.Id);
        }

        private async Task CheckEntityClaimAsync(int applicationId, int userId, IList<Role> roles, string entity, Crud crud)
        {
            var userIsAuthorized = await _userEntityClaimManager.UserIsAuthorizedForEntityClaimAsync(applicationId, userId, entity, crud);
            var roleIsAuthorized = await _roleEntityClaimManager.RolesAreAuthorizedForEntityClaimAsync(applicationId, roles, entity, crud);

            if (userIsAuthorized || roleIsAuthorized)
            {
                return;
            }

            throw new KeyNotFoundException("Bu kullanıcı ya da rol, bu işlem için yetkili değil");
        }

        private async Task AuthorizeWithCustomClaimAsync(int applicationId, int userId, IList<Role> roles, int claimId)
        {
            var userIsAuthorized = await _userClaimManager.UserIsAuthorizedForClaimAsync(applicationId, userId, claimId);
            var roleIsAuthorized = await _roleClaimManager.RolesAreAuthorizedForClaimAsync(applicationId, roles, claimId);
            if (userIsAuthorized || roleIsAuthorized)
            {
                return;
            }

            throw new KeyNotFoundException("Bu kullanıcı ya da rol, bu işlem için yetkili değil");
        }

    }

}