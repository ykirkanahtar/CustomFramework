using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Enums;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Response;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + "match")]
    public class MatchController : Controller
    {
        private readonly IMatchManager _matchManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<MatchController> _logger;
        private readonly IMapper _mapper;

        public MatchController(IMatchManager matchManager, ILocalizationService localizationService, ILogger<MatchController> logger, IMapper mapper)
        {
            _matchManager = matchManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.Match), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] MatchRequest request)
        {
            var result = await _matchManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.Match), Crud.Update)]
        public async Task<IActionResult> UpdateName(int id, [FromBody] MatchRequest request)
        {
            var result = await _matchManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.Match), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _matchManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _matchManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Match, MatchResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await _matchManager.GetAllAsync();

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Match>, IList<MatchResponse>>(result.EntityList), result.Count));
        }
    }
}