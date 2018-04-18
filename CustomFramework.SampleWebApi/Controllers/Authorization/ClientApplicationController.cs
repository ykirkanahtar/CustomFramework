using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Response;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers.Authorization
{
    [Route(ApiConstants.AdminRoute + "clientapplication")]
    public class ClientApplicationController : Controller
    {
        private readonly IClientApplicationManager _clientApplicationManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<ClientApplicationController> _logger;
        private readonly IMapper _mapper;

        public ClientApplicationController(IClientApplicationManager clientApplicationManager, ILocalizationService localizationService, ILogger<ClientApplicationController> logger, IMapper mapper)
        {
            _clientApplicationManager = clientApplicationManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClientApplicationRequest request)
        {
            var result = await _clientApplicationManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationName(int id, [FromBody] ClientApplicationUpdateRequest request)
        {
            var result = await _clientApplicationManager.UpdateClientApplicationAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("{id:int}/update/clientapplicationpassword")]
        [HttpPut]
        [AllowAnonymous]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationPassword(int id, [FromBody] string clientApplicationPassword)
        {
            var result = await _clientApplicationManager.UpdateClientApplicationPasswordAsync(id, clientApplicationPassword);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientApplicationManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientApplicationManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("get/clientapplicationcode/{clientapplicationcode}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.ClientApplication), Crud.Select)]
        public async Task<IActionResult> GetByClientApplicationCode(string clientapplicationcode)
        {
            var result = await _clientApplicationManager.GetByClientApplicationCodeAsync(clientapplicationcode);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }
    }
}
