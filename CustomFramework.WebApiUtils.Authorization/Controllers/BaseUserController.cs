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
using System.Linq;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseUserController : BaseControllerWithCrdAuthorization<User, UserRequest, UserResponse, IUserManager, int>
    {
        public BaseUserController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IUserManager manager) 
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(User), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(User), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("{id:int}/update/namesurname")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public Task<IActionResult> UpdateNameSurnameAsync(int id, [FromBody] UserNameSurnameUpdate nameSurname)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateNameSurnameAsync(id, nameSurname);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("{id:int}/update/userName")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public Task<IActionResult> UpdateUsernameAsync(int id, [FromBody] string userName)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateUserNameAsync(id, userName);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("{id:int}/update/password")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public Task<IActionResult> UpdatePasswordAsync(int id, [FromBody] string password)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdatePasswordAsync(id, password);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("{id:int}/update/email")]
        [HttpPut]
        [Permission(nameof(User), Crud.Update)]
        public Task<IActionResult> UpdateEmailAsync(int id, [FromBody]  string email)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateEmailAsync(id, email);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("get/username/{userName}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public Task<IActionResult> GetByUserNameAsync(string userName)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByUserNameAsync(userName);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("get/email/{email}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public Task<IActionResult> GetByEmailAsync(string email)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByEmailAsync(email);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<User, UserResponse>(result)));
            });
        }

        [Route("getall/keyword/{keyword}/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public Task<IActionResult> GetAllByKeywordAsync(string keyword, int pageIndex, int pageSize)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllByKeywordAsync(keyword, pageIndex, pageSize);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
            });
        }

        [Route("getall/last10user")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public Task<IActionResult> GetAllLast10UserAsync()
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllLast10UserAsync();
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
            });
        }

        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(User), Crud.Select)]
        public Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync(pageIndex, pageSize);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<User>, IList<UserResponse>>(result.ResultList.ToList()), result.Count));
            });
        }

    }
}
