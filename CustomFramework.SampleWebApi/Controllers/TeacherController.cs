using System.Collections.Generic;
using System.Threading.Tasks;
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

namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + nameof(Teacher))]
    public class TeacherController : BaseControllerWithAuthorizationAndUpdate<Teacher, TeacherRequest, TeacherRequest, TeacherResponse, ITeacherManager, int>
    {

        public TeacherController(ITeacherManager teacherManager, ILocalizationService localizationService, ILogger<TeacherController> logger, IMapper mapper)
        : base(teacherManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Teacher), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] TeacherRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(Teacher), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] TeacherRequest request)
        {
            return await BaseUpdate(id, request);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Teacher), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(Teacher), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/teacherNo/{teacherNo:int}")]
        [HttpGet]
        [Permission(nameof(Teacher), Crud.Select)]
        public async Task<IActionResult> GetByTeacherNo(int teacherNo)
        {
            var result = await Manager.GetByTeacherNoAsync(teacherNo);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Teacher, TeacherResponse>(result)));
        }
        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Teacher), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResponse>>(result.ResultList), result.Count));
        }

    }
}