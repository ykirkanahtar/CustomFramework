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
    [Route(ApiConstants.DefaultRoute + "team")]
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<TeamController> _logger;
        private readonly IMapper _mapper;

        public TeamController(ITeamManager teamManager, ILocalizationService localizationService, ILogger<TeamController> logger, IMapper mapper)
        {
            _teamManager = teamManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.Team), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] TeamRequest request)
        {
            var result = await _teamManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Team, TeamResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.Team), Crud.Update)]
        public async Task<IActionResult> UpdateName(int id, [FromBody] TeamRequest request)
        {
            var result = await _teamManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Team, TeamResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.Team), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _teamManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Team, TeamResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await _teamManager.GetAllAsync();

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Team>, IList<TeamResponse>>(result.EntityList), result.Count));
        }
    }
}