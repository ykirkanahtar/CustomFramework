using System.Collections.Generic;
using System.Linq;
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
    [Route(ApiConstants.DefaultRoute + nameof(Student))]
    public class StudentController : BaseControllerWithCrudAuthorization<Student, StudentRequest, StudentRequest, StudentResponse, IStudentManager, int>
    {

        public StudentController(IStudentManager studentManager, ILocalizationService localizationService, ILogger<StudentController> logger, IMapper mapper)
        : base(studentManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Student), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] StudentRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(Student), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] StudentRequest request)
        {
            return await BaseUpdate(id, request);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Student), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(Student), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/studentNo/{studentNo:int}")]
        [HttpGet]
        [Permission(nameof(Student), Crud.Select)]
        public async Task<IActionResult> GetByStudentNo(int studentNo)
        {
            var result = await Manager.GetByStudentNoAsync(studentNo);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Student, StudentResponse>(result)));
        }
        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Student), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IEnumerable<Student>, IEnumerable<StudentResponse>>(result.ResultList), result.Count));
        }
        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(Student), Crud.Select)]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var result = await Manager.GetAllAsync(pageIndex, pageSize);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Student>, IList<StudentResponse>>(result.ResultList.ToList()), result.Count));
        }

    }
}