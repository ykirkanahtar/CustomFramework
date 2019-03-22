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

        [Route("{id:int}/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TUserUpdateRequest request)
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
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userManager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userManager.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("Kullanıcı bulunamadı");
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TUser, TUserResponse>(user)));
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userManager.GetAllUsersAsync();
            if (users == null)
                throw new ArgumentException("Kullanıcı bulunamadı");
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<List<TUser>, List<TUserResponse>>(users)));
        }
    }
}