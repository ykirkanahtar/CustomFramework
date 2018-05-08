using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseController<TEntity, TCreateRequest, TResponse, TManager, TKey> : Controller
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>
    {
        protected readonly TManager Manager;
        protected readonly ILocalizationService LocalizationService;
        protected readonly ILogger<Controller> Logger;
        protected readonly IMapper Mapper;

        protected BaseController(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        {
            Manager = manager;
            LocalizationService = localizationService;
            Logger = logger;
            Mapper = mapper;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateRequest request)
        {
            var result = await Manager.CreateAsync(request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(TKey id)
        {
            await Manager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        [Route("get/id/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(TKey id)
        {
            var result = await Manager.GetByIdAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}