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
    public class BaseUserRoleController : BaseControllerWithCrdAuthorization<UserRole, UserRoleRequest, UserRoleResponse, IUserRoleManager, int>
    {
        public BaseUserRoleController(IUserRoleManager userRoleManager, ILocalizationService localizationService, ILogger<BaseUserRoleController> logger, IMapper mapper)
            : base(userRoleManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(UserRole), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] UserRoleRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete")]
        [HttpDelete]
        [Permission(nameof(UserRole), Crud.Delete)]
        public Task<IActionResult> DeleteAsync([FromBody] UserRoleRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                await Manager.DeleteAsync(request.UserId, request.RoleId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/users/roleid/{roleId:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public Task<IActionResult> GetUsersByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetUsersByRoleIdAsync(roleId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList),
                    result.Count));
            });
        }

        [Route("get/role/userid/{userId:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public Task<IActionResult> GetRolesByUserIdAsync(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetRolesByUserIdAsync(userId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Role>, IList<RoleResponse>>(result.ResultList),
                    result.Count));
            });
        }

    }
}
