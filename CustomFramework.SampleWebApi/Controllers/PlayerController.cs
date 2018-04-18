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
    [Route(ApiConstants.DefaultRoute + "player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerManager _playerManager;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerManager playerManager, ILocalizationService localizationService, ILogger<PlayerController> logger, IMapper mapper)
        {
            _playerManager = playerManager;
            _localizationService = localizationService;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(WebApiEntities.Player), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] PlayerRequest request)
        {
            var result = await _playerManager.CreateAsync(request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Player, PlayerResponse>(result)));
        }

        [Route("{id:int}/update")]
        [HttpPut]
        [Permission(nameof(WebApiEntities.Player), Crud.Update)]
        public async Task<IActionResult> UpdateName(int id, [FromBody] PlayerRequest request)
        {
            var result = await _playerManager.UpdateAsync(id, request);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Player, PlayerResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(WebApiEntities.Player), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            await _playerManager.DeleteAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(true));
        }
        [Route("get/id/{id:int}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _playerManager.GetByIdAsync(id);
            return Ok(new ApiResponse(_localizationService, _logger).Ok(_mapper.Map<Player, PlayerResponse>(result)));
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await _playerManager.GetAllAsync();

            return Ok(new ApiResponse(_localizationService, _logger).Ok(
                _mapper.Map<IList<Player>, IList<PlayerResponse>>(result.EntityList), result.Count));
        }
    }
}