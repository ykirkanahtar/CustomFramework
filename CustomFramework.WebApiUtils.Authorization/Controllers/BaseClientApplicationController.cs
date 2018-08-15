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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseClientApplicationController 
        : BaseControllerWithCrdAuthorization<ClientApplication, ClientApplicationRequest, ClientApplicationResponse, IClientApplicationManager, int>
    {

        public BaseClientApplicationController(IClientApplicationManager clientApplicationManager, ILocalizationService localizationService, ILogger<BaseClientApplicationController> logger, IMapper mapper)
            : base(clientApplicationManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(ClientApplication), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClientApplicationRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(ClientApplication), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(ClientApplication), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(ClientApplication), Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationName(int id, [FromBody] ClientApplicationUpdateRequest request)
        {
            var result = await Manager.UpdateAsync(id, request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("{id:int}/update/clientApplicationPassword")]
        [HttpPut]
        [AllowAnonymous]
        [Permission(nameof(ClientApplication), Crud.Update)]
        public async Task<IActionResult> UpdateClientApplicationPassword(int id, [FromBody] string clientApplicationPassword)
        {
            var result = await Manager.UpdateClientApplicationPasswordAsync(id, clientApplicationPassword);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }

        [Route("get/clientapplicationcode/{clientApplicationCode}")]
        [HttpGet]
        [Permission(nameof(ClientApplication), Crud.Select)]
        public async Task<IActionResult> GetByClientApplicationCode(string clientApplicationCode)
        {
            var result = await Manager.GetByClientApplicationCodeAsync(clientApplicationCode);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
        }
    }
}
