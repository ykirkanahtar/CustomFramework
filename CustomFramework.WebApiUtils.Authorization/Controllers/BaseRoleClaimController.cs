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
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseRoleClaimController : BaseControllerWithAuthorization<RoleClaim, RoleClaimRequest, RoleClaimResponse, IRoleClaimManager, int>
    {
        public BaseRoleClaimController(IRoleClaimManager roleClaimManager, ILocalizationService localizationService, ILogger<BaseRoleClaimController> logger, IMapper mapper)
            : base(roleClaimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(RoleClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleClaimRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(RoleClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/roles/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetRolesByClaimId(int claimId)
        {
            var result = await Manager.GetRolesByClaimIdAsync(claimId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Role>, IList<RoleResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/claim/roleid/{id:int}")]
        [HttpGet]
        [Permission(nameof(RoleClaim), Crud.Select)]
        public async Task<IActionResult> GetClaimsByRoleId(int roleId)
        {
            var result = await Manager.GetClaimsByRoleIdAsync(roleId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
