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

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TRoleRequest request)
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
        }

        [Route("{id:int}/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TRoleRequest request)
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
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _roleManager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var role = await _roleManager.GetByIdAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
        }

        [Route("get/name/{name}")]
        [HttpGet]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var role = await _roleManager.GetByNameAsync(name);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TRole, TRoleResponse>(role)));
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleManager.GetAllAsync();
            if (roles == null)
                throw new ArgumentException("Rolbulunamadı");
            return Ok(new ApiResponse(LocalizationService, Logger).Ok<TRoleResponse>(Mapper.Map<IList<TRole>, IList<TRoleResponse>>(roles), roles.Count));
        }

    }
}