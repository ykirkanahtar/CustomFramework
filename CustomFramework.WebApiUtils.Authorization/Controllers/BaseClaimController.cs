using System.Collections.Generic;
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
    public class BaseClaimController : Controller
    {
        private readonly IClaimManager _claimManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<BaseClaimController> _logger;
        private readonly IMapper _mapper;

        public BaseClaimController(IClaimManager claimManager, ILocalizationService localizationService, ILogger<BaseClaimController> logger, IMapper mapper)
        {
            _claimManager = claimManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] ClaimRequest request)
        {
            var result = await _claimManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] ClaimRequest request)
        {
            var result = await _claimManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _claimManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _claimManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("get/customclaim/{customclaim}")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Select)]
        public async Task<IActionResult> GetByCustomClaim(CustomClaim customClaim)
        {
            var result = await _claimManager.GetByCustomClaimAsync(customClaim);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Claim, ClaimResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [Permission(nameof(AuthorizationEntities.Claim), Crud.Select)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _claimManager.GetAllAsync();
            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Claim>, IList<ClaimResponse>>(result.EntityList),
                result.Count));
        }
    }
}
