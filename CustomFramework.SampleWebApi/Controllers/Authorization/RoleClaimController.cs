using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "roleclaim")]
    public class RoleClaimController : Controller
    {
        private readonly IRoleClaimManager _roleClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<RoleClaimController> _logger;
        private readonly IMapper _mapper;

        public RoleClaimController(IRoleClaimManager roleClaimManager, ILocalizationService localizationService, ILogger<RoleClaimController> logger, IMapper mapper)
        {
            _roleClaimManager = roleClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("addroletoclaim")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.RoleClaim), Crud.Create)]
        public async Task<IActionResult> AddRoleToClaim([FromBody] RoleClaimRequest request)
        {
            var result = await _roleClaimManager.AddRoleToClaimAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("{id:int}/removerolefromclaim")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.RoleClaim), Crud.Delete)]
        public async Task<IActionResult> RemoveRoleFromClaim(int id)
        {
            var result = await _roleClaimManager.RemoveRoleFromClaimAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleClaim, RoleClaimResponse>(result)));
        }

        [Route("get/roles/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetRolesByClaimId(int claimId)
        {
            var result = await _roleClaimManager.GetRolesByClaimIdAsync(claimId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Role>, IList<RoleResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/claim/roleid/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetClaimsByRoleId(int roleId)
        {
            var result = await _roleClaimManager.GetClaimsByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.EntityList),
                result.Count));
        }

    }
}
