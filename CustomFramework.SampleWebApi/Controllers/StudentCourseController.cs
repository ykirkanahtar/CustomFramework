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
    [Route(ApiConstants.DefaultRoute + nameof(StudentCourse))]
    public class StudentCourseController : BaseControllerWithAuthorization<StudentCourse, StudentCourseRequest, StudentCourseResponse, IStudentCourseManager, int>
    {

        public StudentCourseController(IStudentCourseManager studentcourseManager, ILocalizationService localizationService, ILogger<StudentCourseController> logger, IMapper mapper)
        : base(studentcourseManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(StudentCourse), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] StudentCourseRequest request)
        {
            return await BaseCreate(request);
        }



        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(StudentCourse), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(StudentCourse), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall/studentId/{studentId:int}")]
        [HttpGet]
        [Permission(nameof(StudentCourse), Crud.Select)]
        public async Task<IActionResult> GetAllByStudentId(int studentId)
        {
            var result = await Manager.GetAllByStudentIdAsync(studentId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<StudentCourse>, IList<StudentCourseResponse>>(result.ResultList), result.Count));
        }
        [Route("getall/courseId/{courseId:int}")]
        [HttpGet]
        [Permission(nameof(StudentCourse), Crud.Select)]
        public async Task<IActionResult> GetAllByCourseId(int courseId)
        {
            var result = await Manager.GetAllByCourseIdAsync(courseId);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<StudentCourse>, IList<StudentCourseResponse>>(result.ResultList), result.Count));
        }

    }
}