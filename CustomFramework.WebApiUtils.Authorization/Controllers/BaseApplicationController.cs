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
    public class BaseApplicationController : BaseControllerWithCrudAuthorization<Application, ApplicationRequest, ApplicationRequest, ApplicationResponse, IApplicationManager, int>
    {
        public BaseApplicationController(IApplicationManager applicationManager, ILocalizationService localizationService, ILogger<BaseApplicationController> logger, IMapper mapper)
            : base(applicationManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Application), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ApplicationRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(Application), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ApplicationRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Application), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/name/{name}")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await Manager.GetByNameAsync(name);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Application, ApplicationResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Role), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResponse>>(result.ResultList),
                result.Count));
        }
    }
}
