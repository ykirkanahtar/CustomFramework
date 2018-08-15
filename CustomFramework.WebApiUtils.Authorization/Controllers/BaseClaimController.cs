using System.Collections.Generic;
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
    public class BaseClaimController : BaseControllerWithCrudAuthorization<Claim, ClaimRequest, ClaimRequest, ClaimResponse, IClaimManager, int>
    {
        public BaseClaimController(IClaimManager claimManager, ILocalizationService localizationService, ILogger<BaseClaimController> logger, IMapper mapper)
            : base(claimManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Claim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClaimRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(Claim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ClaimRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Claim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/customclaim/{customClaim}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetByCustomClaim(string customClaim)
        {
            var result = await Manager.GetByCustomClaimAsync(customClaim);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var result = await Manager.GetAllAsync(pageIndex, pageSize);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.ResultList),
                result.Count));
        }
    }
}
