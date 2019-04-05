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

        public virtual Task<IActionResult> CreateAsync([FromBody] TRoleRequest request)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var role = Mapper.Map<TRole>(request);

                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
            });
        }

        public virtual Task<IActionResult> UpdateAsync(int id, [FromBody] TRoleRequest request)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var role = await _roleManager.GetByIdAsync(id);
                Mapper.Map(request, role);

                var result = await _roleManager.UpdateAsync(id, role);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
            });
        }

        public virtual Task<IActionResult> DeleteAsync(int id)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                await _roleManager.DeleteAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }

        public virtual Task<IActionResult> GetByIdAsync(int id)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var role = await _roleManager.GetByIdAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
            });
        }

        public virtual Task<IActionResult> GetByNameAsync(string name)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var role = await _roleManager.GetByNameAsync(name);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
            });
        }

        public virtual Task<IActionResult> GetAllAsync()
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var roles = await _roleManager.GetAllAsync();
                if (roles == null || roles.Count == 0)
                    throw new ArgumentException("Rolbulunamadı");
                return Ok(new ApiResponse(LocalizationService, Logger).Ok<TRoleResponse>(Mapper.Map<IList<TRole>, IList<TRoleResponse>>(roles), roles.Count));
            });
        }

        [NonAction]
        public Task<IActionResult> BaseAddClaimsAsync(int id, IList<ClaimRequest> claimsRequest, IList<ClaimRequest> existingClaimsRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
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
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(claimsResponse));
            });
        }

        [NonAction]
        public Task<IActionResult> BaseAddClaimAsync(int id, ClaimRequest claimRequest, IList<ClaimRequest> existingClaimsRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var existingClaims = Mapper.Map<IList<Claim>>(existingClaimsRequest);

                var result = await _roleManager.AddClaimAsync(id, claim, existingClaims);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }

        public virtual Task<IActionResult> GetClaimsAsync(string roleName)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claims = await _roleManager.GetClaimsAsync(roleName);
                if (claims == null || claims.Count == 0)
                    throw new KeyNotFoundException("Yetki bulunamadı");
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<IList<Claim>, IList<ClaimResponse>>(claims), claims.Count));
            });
        }

        public virtual Task<IActionResult> RemoveClaimsAsync(int id, [FromBody] List<ClaimRequest> claimsRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
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
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(claimsResponse));
            });
        }

        public virtual Task<IActionResult> RemoveClaimAsync(int id, [FromBody] ClaimRequest claimRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var result = await _roleManager.RemoveClaimAsync(id, claim);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }
    }
}