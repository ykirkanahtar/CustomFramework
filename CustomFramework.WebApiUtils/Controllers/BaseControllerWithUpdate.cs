using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseControllerWithUpdate<TEntity, TCreateRequest, TUpdateRequest, TResponse, TManager, TKey>
        : BaseController<TEntity, TCreateRequest, TResponse, TManager, TKey>
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>, IBusinessManagerUpdate<TEntity, TUpdateRequest, TKey>
    {

        protected BaseControllerWithUpdate(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        : base(manager, localizationService, logger, mapper)
        {

        }

        [Route("{id:int}/update")]
        [HttpPut]
        public async Task<IActionResult> Update(TKey id, [FromBody] TUpdateRequest request)
        {
            var result = await Manager.UpdateAsync(id, request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}