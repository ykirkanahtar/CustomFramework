using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseRoleEntityClaimController : Controller
    {
        private readonly IRoleEntityClaimManager _roleEntityClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseRoleEntityClaimController> _logger;
        private readonly IMapper _mapper;

        public BaseRoleEntityClaimController(IRoleEntityClaimManager roleEntityClaimManager, ILocalizationService localizationService, ILogger<BaseRoleEntityClaimController> logger, IMapper mapper)
        {
            _roleEntityClaimManager = roleEntityClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleEntityClaimRequest request)
        {
            var result = await _roleEntityClaimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            var result = await _roleEntityClaimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleEntityClaimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _roleEntityClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<RoleEntityClaim, RoleEntityClaimResponse>(result)));
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(string entity)
        {
            var result = await _roleEntityClaimManager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<RoleEntityClaim>, IList<RoleEntityClaimResponse>>(result.EntityList),
                result.Count));
        }

        [Route("getall/roleid/{roleid:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByRoleId(int roleId)
        {
            var result = await _roleEntityClaimManager.GetAllByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<RoleEntityClaim>, IList<RoleEntityClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
