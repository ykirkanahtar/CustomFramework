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
    public class BaseApplicationController : BaseControllerWithCrudAuthorization<Application, ApplicationRequest, ApplicationRequest, ApplicationResponse, IApplicationManager, int>
    {
        public BaseApplicationController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IApplicationManager manager) 
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Application), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] ApplicationRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(Application), Crud.Update)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ApplicationRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Application), Crud.Delete)]
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

        [Route("get/name/{name}")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public Task<IActionResult> GetByNameAsync(string name)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByNameAsync(name);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Application, ApplicationResponse>(result)));
            }, name);
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
                    Mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResponse>>(result.ResultList),
                    result.Count));
            }, null);
        }
    }
}
