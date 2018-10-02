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
    public class BaseRoleController : BaseControllerWithCrudAuthorization<Role, RoleRequest, RoleRequest, RoleResponse, IRoleManager, int>
    {
        public BaseRoleController(IRoleManager roleManager, ILocalizationService localizationService, ILogger<BaseRoleController> logger, IMapper mapper)
            : base(roleManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Role), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] RoleRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(Role), Crud.Update)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RoleRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Role), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/rolename/{roleName}")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public Task<IActionResult> GetByRoleNameAsync(string roleName)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByNameAsync(roleName);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Role, RoleResponse>(result)));
            });
        }

        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public Task<IActionResult> GetAllAsync()
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync();
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IEnumerable<Role>, IEnumerable<RoleResponse>>(result.ResultList),
                    result.Count));
            });
        }
    }
}
