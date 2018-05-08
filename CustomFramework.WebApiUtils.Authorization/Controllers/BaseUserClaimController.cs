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
    public class BaseUserClaimController : BaseControllerWithAuthorization<UserClaim, UserClaimRequest, UserClaimResponse, IUserClaimManager, int>
    {
        public BaseUserClaimController(IUserClaimManager userClaimManager, ILocalizationService localizationService, ILogger<BaseUserClaimController> logger, IMapper mapper)
            : base(userClaimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserClaimRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(UserClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/users/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public async Task<IActionResult> GetUsersByClaimId(int claimId)
        {
            var result = await Manager.GetUsersByClaimIdAsync(claimId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<User>, IEnumerable<UserResponse>>(result.ResultList),
                result.Count));
        }

        [Route("get/claim/userid/{id:int}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public async Task<IActionResult> GetClaimsByUserId(int userId)
        {
            var result = await Manager.GetClaimsByUserIdAsync(userId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<Claim>, IEnumerable<ClaimResponse>>(result.ResultList),
                result.Count));
        }
    }
}
