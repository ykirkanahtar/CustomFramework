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
    public class BaseRoleController : Controller
    {
        private readonly IRoleManager _roleManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseRoleController> _logger;
        private readonly IMapper _mapper;

        public BaseRoleController(IRoleManager roleManager, ILocalizationService localizationService, ILogger<BaseRoleController> logger, IMapper mapper)
        {
            _roleManager = roleManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] RoleRequest request)
        {
            var result = await _roleManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("{id:int}/update/rolename")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Update)]
        public async Task<IActionResult> UpdateRoleName(int id, [FromBody] RoleRequest request)
        {
            var result = await _roleManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }

        [Route("get/rolename/{rolename}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Select)]
        public async Task<IActionResult> GetByRoleName(string roleName)
        {
            var result = await _roleManager.GetByNameAsync(roleName);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Role, RoleResponse>(result)));
        }


        [Route("getall")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Role), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleManager.GetAllAsync();
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Role>, IList<RoleResponse>>(result.EntityList),
                result.Count));
        }


    }
}
