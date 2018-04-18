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
    public class BaseUserEntityClaimController : Controller
    {
        private readonly IUserEntityClaimManager _userEntityClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseUserEntityClaimController> _logger;
        private readonly IMapper _mapper;

        public BaseUserEntityClaimController(IUserEntityClaimManager userEntityClaimManager, ILocalizationService localizationService, ILogger<BaseUserEntityClaimController> logger, IMapper mapper)
        {
            _userEntityClaimManager = userEntityClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserEntityClaimRequest request)
        {
            var result = await _userEntityClaimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] EntityClaimRequest request)
        {
            var result = await _userEntityClaimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userEntityClaimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _userEntityClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserEntityClaim, UserEntityClaimResponse>(result)));
        }

        [Route("getall/entity/{entity}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByEntity(string entity)
        {
            var result = await _userEntityClaimManager.GetAllByEntityAsync(entity);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }

        [Route("getall/Userid/{Userid:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserEntityClaim), Crud.Select)]
        public async Task<IActionResult> GetAllByUserId(int userId)
        {
            var result = await _userEntityClaimManager.GetAllByUserIdAsync(userId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<UserEntityClaim>, IList<UserEntityClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
