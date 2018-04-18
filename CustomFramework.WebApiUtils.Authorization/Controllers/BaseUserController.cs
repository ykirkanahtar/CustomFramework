using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Enums;
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
    public class BaseUserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseUserController> _logger;
        private readonly IMapper _mapper;

        public BaseUserController(IUserManager userManager, ILocalizationService localizationService, ILogger<BaseUserController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.User), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var result = await _userManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/username")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.User), Crud.Update)]
        public async Task<IActionResult> UpdateUsername(int id, [FromBody] string userName)
        {
            var result = await _userManager.UpdateUserNameAsync(id, userName);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/password")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.User), Crud.Update)]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] string password)
        {
            var result = await _userManager.UpdatePasswordAsync(id, password);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("{id:int}/update/email")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.User), Crud.Update)]
        public async Task<IActionResult> UpdateEmail(int id, [FromBody]  string email)
        {
            var result = await _userManager.UpdateEmailAsync(id, email);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.User), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.User), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _userManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("get/username/{username}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.User), Crud.Select)]
        public async Task<IActionResult> GetByUserName(string userName)
        {

            var result = await _userManager.GetByUserNameAsync(userName);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }

        [Route("get/email/{email}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.User), Crud.Select)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _userManager.GetByEmailAsync(email);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<User, UserResponse>(result)));
        }
    }
}
