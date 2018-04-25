using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
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
    public class BaseRoleEntityClaimController
        : BaseControllerWithAuthorizationAndUpdate<RoleEntityClaim, RoleEntityClaimRequest, EntityClaimRequest, RoleEntityClaimResponse, IRoleEntityClaimManager, int>
    {
        public BaseRoleEntityClaimController(IRoleEntityClaimManager roleEntityClaimManager, ILocalizationService localizationService, ILogger<BaseRoleEntityClaimController> logger, IMapper mapper)
            : base(roleEntityClaimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(RoleEntityClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleEntityClaimRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(RoleEntityClaim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(RoleEntityClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(string entity)
        {
            var result = await Manager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<RoleEntityClaim>, IEnumerable<RoleEntityClaimResponse>>(result.ResultList),
                result.Count));
        }

        [Route("getall/roleid/{roleid:int}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByRoleId(int roleId)
        {
            var result = await Manager.GetAllByRoleIdAsync(roleId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<RoleEntityClaim>, IEnumerable<RoleEntityClaimResponse>>(result.ResultList),
                result.Count));
        }
    }
}
