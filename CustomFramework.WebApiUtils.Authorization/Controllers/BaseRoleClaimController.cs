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
    public class BaseRoleClaimController : BaseControllerWithCrdAuthorization<RoleClaim, RoleClaimRequest, RoleClaimResponse, IRoleClaimManager, int>
    {
        public BaseRoleClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IRoleClaimManager manager) 
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(RoleClaim), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] RoleClaimRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(RoleClaim), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/roles/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public Task<IActionResult> GetRolesByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetRolesByClaimIdAsync(claimId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Role>, IList<RoleResponse>>(result.ResultList),
                    result.Count));
            });
        }

        [Route("get/claim/roleid/{id:int}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public Task<IActionResult> GetClaimsByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetClaimsByRoleIdAsync(roleId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }
    }
}
