using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.EmailProvider;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Controllers;
using CustomFramework.WebApiUtils.Identity.Business;
using CustomFramework.WebApiUtils.Identity.Constants;
using CustomFramework.WebApiUtils.Identity.Contracts.Requests;
using CustomFramework.WebApiUtils.Identity.Contracts.Responses;
using CustomFramework.WebApiUtils.Identity.Extensions;
using CustomFramework.WebApiUtils.Identity.Models;
using CustomFramework.WebApiUtils.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomFramework.WebApiUtils.Identity.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseRoleController<TRole, TRoleRequest, TRoleResponse> : BaseController
    where TRole : CustomRole
    where TRoleRequest : CustomRoleRequest
    where TRoleResponse : CustomRoleResponse
    {
        private readonly ICustomRoleManager<TRole> _roleManager;
        public BaseRoleController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, ICustomRoleManager<TRole> roleManager) : base(localizationService, logger, mapper)
        {
            _roleManager = roleManager;
        }

        public async virtual Task<IActionResult> CreateAsync([FromBody] TRoleRequest request)
        {
            var result = await CommonOperationAsync<TRole>(async() =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var role = Mapper.Map<TRole>(request);

                var response = await _roleManager.CreateAsync(role);
                if (!response.Succeeded)
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }
                return role;
            });

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(result)));
        }

        public async virtual Task<IActionResult> UpdateAsync(int id, [FromBody] TRoleRequest request)
        {
            var result = await CommonOperationAsync<TRole>(async() =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var role = await _roleManager.GetByIdAsync(id);
                Mapper.Map(request, role);

                var response = await _roleManager.UpdateAsync(id, role);
                if (!response.Succeeded)
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }
                return role;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(result)));

        }

        public async virtual Task<IActionResult> DeleteAsync(int id)
        {
            await _roleManager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        public async virtual Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await CommonOperationAsync<TRole>(async() =>
            {
                return await _roleManager.GetByIdAsync(id);
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(result)));
        }

        public async virtual Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await CommonOperationAsync<TRole>(async() =>
            {
                return await _roleManager.GetByNameAsync(name);
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(result)));
        }

        public async virtual Task<IActionResult> GetAllAsync()
        {
            var result = await CommonOperationAsync<IList<TRole>>(async() =>
            {
                var roles = await _roleManager.GetAllAsync();
                if (roles == null || roles.Count == 0)
                    throw new KeyNotFoundException(IdentityStringMessages.Role);
                return roles;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok<TRoleResponse>(Mapper.Map<IList<TRole>, IList<TRoleResponse>>(result), result.Count));
        }

        [NonAction]
        public async Task<IActionResult> BaseAddClaimsAsync(int id, IList<ClaimRequest> claimsRequest, IList<ClaimRequest> existingClaimsRequest)
        {
            var result = await CommonOperationAsync<List<ClaimResponse>>(async() =>
            {
                var claims = Mapper.Map<IList<Claim>>(claimsRequest);
                var existingClaims = Mapper.Map<IList<Claim>>(existingClaimsRequest);

                var addedClaims = await _roleManager.AddClaimsAsync(id, claims, existingClaims);
                var claimsResponse = new List<ClaimResponse>();
                foreach (var claim in addedClaims)
                {
                    claimsResponse.Add(new ClaimResponse
                    {
                        Type = claim.Type,
                            Value = claim.Value
                    });
                }
                return claimsResponse;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
        }

        [NonAction]
        public async Task<IActionResult> BaseAddClaimAsync(int id, ClaimRequest claimRequest, IList<ClaimRequest> existingClaimsRequest)
        {
            var result = await CommonOperationAsync<bool>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var existingClaims = Mapper.Map<IList<Claim>>(existingClaimsRequest);

                var response = await _roleManager.AddClaimAsync(id, claim, existingClaims);
                if (!response.Succeeded)
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }
                return true;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
        }

        public async virtual Task<IActionResult> GetClaimsAsync(string roleName)
        {
            var result = await CommonOperationAsync<IList<Claim>>(async() =>
            {
                var claims = await _roleManager.GetClaimsAsync(roleName);
                if (claims == null || claims.Count == 0)
                    throw new KeyNotFoundException(IdentityStringMessages.Authority);
                return claims;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result), result.Count));
        }

        public async virtual Task<IActionResult> RemoveClaimsAsync(int id, [FromBody] List<ClaimRequest> claimsRequest)
        {
            var result = await CommonOperationAsync<List<ClaimResponse>>(async() =>
            {
                var claims = Mapper.Map<IList<Claim>>(claimsRequest);

                var removedClaims = await _roleManager.RemoveClaimsAsync(id, claims);
                var claimsResponse = new List<ClaimResponse>();
                foreach (var claim in removedClaims)
                {
                    claimsResponse.Add(new ClaimResponse
                    {
                        Type = claim.Type,
                            Value = claim.Value
                    });
                }
                return claimsResponse;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
        }

        public async virtual Task<IActionResult> RemoveClaimAsync(int id, [FromBody] ClaimRequest claimRequest)
        {
            var result = await CommonOperationAsync<bool>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var response = await _roleManager.RemoveClaimAsync(id, claim);
                if (!response.Succeeded)
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }
                return true;
            });
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(result));
        }
    }
}