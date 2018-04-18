using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "userclaim")]
    public class UserClaimController : Controller
    {
        private readonly IUserClaimManager _userClaimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<UserClaimController> _logger;
        private readonly IMapper _mapper;

        public UserClaimController(IUserClaimManager userClaimManager, ILocalizationService localizationService, ILogger<UserClaimController> logger, IMapper mapper)
        {
            _userClaimManager = userClaimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("addusertoclaim")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.UserClaim), Crud.Create)]
        public async Task<IActionResult> AddUserToClaim([FromBody] UserClaimRequest request)
        {
            var result = await _userClaimManager.AddUserToClaimAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("{id:int}/removeuserfromclaim")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.UserClaim), Crud.Delete)]
        public async Task<IActionResult> RemoveUserFromClaim(int id)
        {
            var result = await _userClaimManager.RemoveUserFromClaimAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserClaim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userClaimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserClaim, UserClaimResponse>(result)));
        }

        [Route("get/users/claimid/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserClaim), Crud.Select)]
        public async Task<IActionResult> GetUsersByClaimId(int claimId)
        {
            var result = await _userClaimManager.GetUsersByClaimIdAsync(claimId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<User>, IList<UserResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/claim/userid/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserClaim), Crud.Select)]
        public async Task<IActionResult> GetClaimsByUserId(int userId)
        {
            var result = await _userClaimManager.GetClaimsByUserIdAsync(userId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
