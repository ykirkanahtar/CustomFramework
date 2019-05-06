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
    public class BaseApplicationUserController : BaseControllerWithCrdAuthorization<ApplicationUser, ApplicationUserRequest, ApplicationUserResponse, IApplicationUserManager, int>
    {
        public BaseApplicationUserController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IApplicationUserManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(ApplicationUser), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] ApplicationUserRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(ApplicationUser), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(ApplicationUser), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/users/applicationid/{applicationid:int}")]
        [HttpGet]
        [Permission(nameof(ApplicationUser), Crud.Select)]
        public Task<IActionResult> GetUsersByApplicationIdAsync(int applicationId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetUsersByApplicationIdAsync(applicationId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList),
                    result.Count));
            }, applicationId);
        }

        [Route("get/application/userid/{userid:int}")]
        [HttpGet]
        [Permission(nameof(UserRole), Crud.Select)]
        public Task<IActionResult> GetRolesByUserIdAsync(int userId)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetApplicationsByUserIdAsync(userId);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Application>, IList<ApplicationResponse>>(result.ResultList),
                    result.Count));
            }, userId);
        }

    }
}
