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
using CustomFramework.Data.Contracts;
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
    public class BaseUserController<TUser, TUserUpdateRequest, TUserResponse> : BaseController
    where TUser : CustomUser
    where TUserUpdateRequest : CustomUserUpdateRequest
    where TUserResponse : CustomUserResponse
    {
        private readonly ICustomUserManager<TUser> _userManager;
        private readonly IEmailSender _emailSender;
        public BaseUserController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, ICustomUserManager<TUser> userManager, IEmailSender emailSender) : base(localizationService, logger, mapper)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public virtual Task<IActionResult> UpdateAsync(int id, [FromBody] TUserUpdateRequest request)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var user = await _userManager.GetByIdAsync(id);
                if (user == null)
                    throw new ArgumentException("Kullanıcı bulunamadı");

                user.BirthDate = request.BirthDate;
                user.FirstName = request.FirstName;
                user.Surname = request.Surname;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                }

                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TUser, TUserResponse>(user)));
            });
        }

        public virtual Task<IActionResult> DeleteAsync(int id)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                await _userManager.DeleteAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }

        public virtual Task<IActionResult> GetByIdAsync(int id)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var user = await _userManager.GetByIdAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TUser, TUserResponse>(user)));
            });
        }

        public virtual Task<IActionResult> GetAllAsync()
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var users = await _userManager.GetAllAsync();
                if (users == null || users.Count == 0)
                    throw new ArgumentException("Kullanıcı bulunamadı");
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<IList<TUser>, IList<TUserResponse>>(users), users.Count));
            });
        }

        public virtual Task<IActionResult> AddToRolesAsync([FromBody] UserAddToRolesRequest request)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var result = await _userManager.AddToRolesAsync(request.UserId, request.Roles);
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

        public virtual Task<IActionResult> RemoveFromRolesAsync([FromBody] UserRemoveFromRolesRequest request)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var result = await _userManager.RemoveFromRolesAsync(request.UserId, request.Roles);
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

        [NonAction]
        public virtual Task<IActionResult> BaseAddClaimAsync(int id, ClaimRequest claimRequest, IList<ClaimRequest> existingClaimsRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var existingClaims = Mapper.Map<IList<Claim>>(existingClaimsRequest);

                var result = await _userManager.AddClaimAsync(id, claim, existingClaims);
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

        public virtual Task<IActionResult> GetUserClaimsAsync(int id)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claims = await _userManager.GetUserClaimsAsync(id);
                if (claims == null || claims.Count == 0)
                    throw new KeyNotFoundException("Yetki bulunamadı");
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<IList<Claim>, IList<ClaimResponse>>(claims), claims.Count));
            });
        }

        public virtual Task<IActionResult> RemoveClaimAsync(int id, [FromBody] ClaimRequest claimRequest)
        {
            return CommonOperationAsync<IActionResult>(async() =>
            {
                var claim = Mapper.Map<Claim>(claimRequest);
                var result = await _userManager.RemoveClaimAsync(id, claim);
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