using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Authorization.Responses;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateAsync([FromBody] ClientApplicationRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(ClientApplication), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(ClientApplication), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(ClientApplication), Crud.Update)]
        public Task<IActionResult> UpdateClientApplicationNameAsync(int id, [FromBody] ClientApplicationUpdateRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
            });
        }

        [Route("{id:int}/update/clientApplicationPassword")]
        [HttpPut]
        [AllowAnonymous]
        [Permission(nameof(ClientApplication), Crud.Update)]
        public Task<IActionResult> UpdateClientApplicationPasswordAsync(int id, [FromBody] string clientApplicationPassword)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateClientApplicationPasswordAsync(id, clientApplicationPassword);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
            });
        }

        [Route("get/clientapplicationcode/{clientApplicationCode}")]
        [HttpGet]
        [Permission(nameof(ClientApplication), Crud.Select)]
        public Task<IActionResult> GetByClientApplicationCodeAsync(string clientApplicationCode)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByClientApplicationCodeAsync(clientApplicationCode);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<ClientApplication, ClientApplicationResponse>(result)));
            });
        }
    }
}
