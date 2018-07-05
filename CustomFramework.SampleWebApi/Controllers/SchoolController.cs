using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.SampleWebApi.Responses;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + nameof(School))]
    public class SchoolController : BaseControllerWithCrudAuthorization<School, SchoolRequest, SchoolRequest, SchoolResponse, ISchoolManager, int>
    {

        public SchoolController(ISchoolManager SchoolManager, ILocalizationService localizationService, ILogger<SchoolController> logger, IMapper mapper)
        : base(SchoolManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(School), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] SchoolRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(School), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] SchoolRequest request)
        {
            return await BaseUpdate(id, request);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(School), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(School), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall")]
        [HttpGet]
        [Permission(nameof(School), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<School>, IEnumerable<SchoolResponse>>(result.ResultList), result.Count));
        }
    }
}