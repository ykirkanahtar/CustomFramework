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
    public class BaseUserEntityClaimController : BaseControllerWithAuthorizationAndUpdate<UserEntityClaim, UserEntityClaimRequest, EntityClaimRequest, UserEntityClaimResponse, IUserEntityClaimManager, int>
    {
        public BaseUserEntityClaimController(IUserEntityClaimManager userEntityClaimManager, ILocalizationService localizationService, ILogger<BaseUserEntityClaimController> logger, IMapper mapper)
            : base(userEntityClaimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserEntityClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserEntityClaimRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(UserEntityClaim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(UserEntityClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(string entity)
        {
            var result = await Manager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }

        [Route("getall/userid/{userid:int}")]
        [HttpGet]
        [Permission(nameof(UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await Manager.GetAllByUserIdAsync(userId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
