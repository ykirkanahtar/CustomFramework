using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Contracts.Responses;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseRoleEntityClaimController
        : BaseControllerWithCrudAuthorization<RoleEntityClaim, RoleEntityClaimRequest, EntityClaimRequest, RoleEntityClaimResponse, IRoleEntityClaimManager, int>
    {
        public BaseRoleEntityClaimController(IRoleEntityClaimManager roleEntityClaimManager, ILocalizationService localizationService, ILogger<BaseRoleEntityClaimController> logger, IMapper mapper)
            : base(roleEntityClaimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(RoleEntityClaim), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] RoleEntityClaimRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(RoleEntityClaim), Crud.Update)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EntityClaimRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(RoleEntityClaim), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public Task<IActionResult> GetAllByEntityAsync(string entity)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByEntityAsync(entity);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<RoleEntityClaim>, IEnumerable<RoleEntityClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }

        [Route("getall/roleid/{roleId:int}")]
        [HttpGet]
        [Permission(nameof(RoleEntityClaim), Crud.Select)]
        public Task<IActionResult> GetAllByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByRoleIdAsync(roleId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<RoleEntityClaim>, IEnumerable<RoleEntityClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }
    }
}
