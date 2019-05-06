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
    public class BaseUserEntityClaimController : BaseControllerWithCrudAuthorization<UserEntityClaim, UserEntityClaimRequest, EntityClaimRequest, UserEntityClaimResponse, IUserEntityClaimManager, int>
    {
        public BaseUserEntityClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserEntityClaimManager manager) 
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserEntityClaim), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] UserEntityClaimRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(UserEntityClaim), Crud.Update)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EntityClaimRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(UserEntityClaim), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public Task<IActionResult> GetAllByEntityAsync(string entity)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByEntityAsync(entity);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }

        [Route("getall/userid/{userId:int}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public Task<IActionResult> GetAllByUserIdAsync(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByUserIdAsync(userId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.ResultList),
                    result.Count));
            });
        }
    }
}
