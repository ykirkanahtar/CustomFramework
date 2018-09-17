using System.Collections.Generic;
using System.Linq;
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
    public class BaseUserController : BaseControllerWithCrdAuthorization<User, UserRequest, UserResponse, IUserManager, int>
    {

        public BaseUserController(IUserManager userManager, ILocalizationService localizationService, ILogger<BaseUserController> logger, IMapper mapper)
            : base(userManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(User), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(User), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("{id:int}/update/userName")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public async Task<IActionResult> UpdateUsername(int id, [FromBody] string userName)
        {
            var result = await Manager.UpdateUserNameAsync(id, userName);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/password")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] string password)
        {
            var result = await Manager.UpdatePasswordAsync(id, password);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/email")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public async Task<IActionResult> UpdateEmail(int id, [FromBody]  string email)
        {
            var result = await Manager.UpdateEmailAsync(id, email);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("get/username/{userName}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetByUserName(string userName)
        {

            var result = await Manager.GetByUserNameAsync(userName);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("get/email/{email}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await Manager.GetByEmailAsync(email);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
        }

        [Route("getall/keyword/{keyword}/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetAllByKeywor(string keyword, int pageIndex, int pageSize)
        {
            var result = await Manager.GetAllByKeywordAsync(keyword, pageIndex, pageSize);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
        }

        [Route("getall/last10user")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetAllLast10User()
        {
            var result = await Manager.GetAllLast10UserAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
        }

        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var result = await Manager.GetAllAsync(pageIndex, pageSize);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
        }

    }
}
