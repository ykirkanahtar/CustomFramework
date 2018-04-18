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
    [Route(ApiConstants.AdminRoute + "userrole")]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleManager _userRoleManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<UserRoleController> _logger;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<UserRoleController> logger, IMapper mapper)
        {
            _userRoleManager = userRoleManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("addusertorole")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.UserRole), Crud.Create)]
        public async Task<IActionResult> AddUserTorole([FromBody] UserRoleRequest request)
        {
            var result = await _userRoleManager.AddUserToRoleAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("{id:int}/removeuserfromrole")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.UserRole), Crud.Delete)]
        public async Task<IActionResult> RemoveUserFromRole(int id)
        {
            var result = await _userRoleManager.RemoveUserFromRoleAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(result));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserRole), Crud.Select)]
        public async Task<IActionResult> GetBydId(int id)
        {
            var result = await _userRoleManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<UserRole, UserRoleResponse>(result)));
        }

        [Route("get/users/roleid/{roleid:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserRole), Crud.Select)]
        public async Task<IActionResult> GetUsersByRoleId(int roleId)
        {
            var result = await _userRoleManager.GetUsersByRoleIdAsync(roleId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<User>, IList<UserResponse>>(result.EntityList),
                result.Count));
        }

        [Route("get/role/userid/{userid:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.UserRole), Crud.Select)]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var result = await _userRoleManager.GetRolesByUserIdAsync(userId);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Role>, IList<RoleResponse>>(result.EntityList),
                result.Count));
        }

    }
}
