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
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BaseClaimController : BaseControllerWithAuthorizationAndUpdate<Claim, ClaimRequest, ClaimRequest, ClaimResponse, IClaimManager, int>
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

        [Route("{id}/update")]
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

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("get/customclaim/{customclaim}")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetByCustomClaim(CustomClaim customClaim)
        {
            var result = await Manager.GetByCustomClaimAsync(customClaim);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [Permission(nameof(Claim), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Manager.GetAllAsync();
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
