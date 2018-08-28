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
    public class BaseUserRoleController : BaseControllerWithCrdAuthorization<UserRole, UserRoleRequest, UserRoleResponse, IUserRoleManager, int>
    {
        public BaseUserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<BaseUserRoleController> logger, IMapper mapper)
            : base(userRoleManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserRole), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserRoleRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete")]
        [HttpDelete]
        [Permission(nameof(UserRole), Crud.Delete)]
        public async Task<IActionResult> Delete([FromBody] UserRoleRequest request)
        {
            await Manager.DeleteAsync(request.UserId, request.RoleId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/users/roleid/{roleId:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public async Task<IActionResult> GetUsersByRoleId(int roleId)
        {
            var result = await Manager.GetUsersByRoleIdAsync(roleId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList),
                result.Count));
        }

        [Route("get/role/userid/{userId:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var result = await Manager.GetRolesByUserIdAsync(userId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Role>, IList<RoleResponse>>(result.ResultList),
                result.Count));
        }

    }
}
