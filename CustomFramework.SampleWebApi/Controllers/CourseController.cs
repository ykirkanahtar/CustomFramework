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
    [Route(ApiConstants.DefaultRoute + nameof(Course))]
    public class CourseController : BaseControllerWithAuthorizationAndUpdate<Course, CourseRequest, CourseRequest, CourseResponse, ICourseManager, int>
    {

        public CourseController(ICourseManager courseManager, ILocalizationService localizationService, ILogger<CourseController> logger, IMapper mapper)
        : base(courseManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Course), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] CourseRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(Course), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] CourseRequest request)
        {
            return await BaseUpdate(id, request);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Course), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(Course), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/courseNo/{courseNo:int}")]
        [HttpGet]
        [Permission(nameof(Course), Crud.Select)]
        public async Task<IActionResult> GetByCourseNo(int courseNo)
        {
            var result = await Manager.GetByCourseNoAsync(courseNo);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Course, CourseResponse>(result)));
        }
        [Route("getall/teacherId/{teacherId:int}")]
        [HttpGet]
        [Permission(nameof(Course), Crud.Select)]
        public async Task<IActionResult> GetAllByTeacherId(int teacherId)
        {
            var result = await Manager.GetAllByTeacherIdAsync(teacherId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Course>, IList<CourseResponse>>(result.ResultList), result.Count));
        }
        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Course), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<Course>, IEnumerable<CourseResponse>>(result.ResultList), result.Count));
        }

    }
}