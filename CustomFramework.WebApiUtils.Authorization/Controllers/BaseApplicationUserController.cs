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
    public class BaseApplicationUserController : BaseControllerWithCrdAuthorization<ApplicationUser, ApplicationUserRequest, ApplicationUserResponse, IApplicationUserManager, int>
    {
        public BaseApplicationUserController(IApplicationUserManager applicationUserManager, ILocalizationService localizationService, ILogger<BaseApplicationUserController> logger, IMapper mapper)
            : base(applicationUserManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(ApplicationUser), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ApplicationUserRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(ApplicationUser), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(ApplicationUser), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/users/applicationid/{applicationid:int}")]
        [HttpGet]
        [Permission(nameof(ApplicationUser), Crud.Select)]
        public async Task<IActionResult> GetUsersByApplicationId(int applicationId)
        {
            var result = await Manager.GetUsersByApplicationIdAsync(applicationId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList),
                result.Count));
        }

        [Route("get/application/userid/{userid:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public async Task<IActionResult> GetRolesByUserId(int userId)
        {
            var result = await Manager.GetApplicationsByUserIdAsync(userId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Application>, IList<ApplicationResponse>>(result.ResultList),
                result.Count));
        }

    }
}
