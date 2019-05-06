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
    public class BaseUserClaimController : BaseControllerWithCrdAuthorization<UserClaim, UserClaimRequest, UserClaimResponse, IUserClaimManager, int>
    {
        public BaseUserClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserClaimManager manager) 
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserClaim), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] UserClaimRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(UserClaim), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/users/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public Task<IActionResult> GetUsersByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetUsersByClaimIdAsync(claimId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<User>, IEnumerable<UserResponse>>(result.ResultList),
                    result.Count));
            });
        }

        [Route("get/claim/userid/{id:int}")]
        [HttpGet]
        [Permission(nameof(UserClaim), Crud.Select)]
        public Task<IActionResult> GetClaimsByUserIdAsync(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetClaimsByUserIdAsync(userId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Claim>, IEnumerable<ClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }
    }
}
