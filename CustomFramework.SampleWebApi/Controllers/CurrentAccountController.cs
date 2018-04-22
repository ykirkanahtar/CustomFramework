using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Resources;
using CustomFramework.SampleWebApi.Response;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route(ApiConstants.DefaultRoute + nameof(CurrentAccount))]
    public class CurrentAccountController
        : BaseControllerWithAuthorizationAndUpdate<CurrentAccount, CurrentAccountRequest, CurrentAccountRequest, CurrentAccountResponse, ICurrentAccountManager2, int>
    {
        public CurrentAccountController(ICurrentAccountManager2 currentAccountManager, ILocalizationService localizationService, ILogger<CurrentAccountController> logger, IMapper mapper)
            : base(currentAccountManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(CurrentAccount), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] CurrentAccountRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(CurrentAccount), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] CurrentAccountRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(CurrentAccount), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(CurrentAccount), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await Manager.GetAllAsync();

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<CurrentAccount>, IList<CurrentAccountResponse>>(result.EntityList), result.Count));
        }
    }
}