using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseControllerWithRd<TEntity, TResponse, TManager, TKey> : BaseController
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TKey>
    {
        protected readonly TManager Manager;

        protected BaseControllerWithRd(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, TManager manager) 
            : base(localizationService, logger, mapper)
        {
            Manager = manager;
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