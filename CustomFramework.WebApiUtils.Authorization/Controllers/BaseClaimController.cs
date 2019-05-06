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
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseClaimController : BaseControllerWithCrudAuthorization<Claim, ClaimRequest, ClaimRequest, ClaimResponse, IClaimManager, int>
    {
        public BaseClaimController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, IClaimManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Claim), Crud.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] ClaimRequest request)
        {
            return await BaseCreateAsync(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(Claim), Crud.Update)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClaimRequest request)
        {
            return await BaseUpdateAsync(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Claim), Crud.Delete)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await BaseDeleteAsync(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return await BaseGetByIdAsync(id);
        }

        [Route("get/customclaim/{customClaim}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public Task<IActionResult> GetByCustomClaimAsync(string customClaim)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByCustomClaimAsync(customClaim);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Claim, ClaimResponse>(result)));
            }, customClaim);
        }

        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetAllAsync(pageIndex, pageSize);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                    Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.ResultList),
                    result.Count));
            }, new List<object> { pageIndex, pageSize });
        }
    }
}
