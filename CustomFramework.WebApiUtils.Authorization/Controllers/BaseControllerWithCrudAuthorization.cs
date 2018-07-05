using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    public abstract class BaseControllerWithCrudAuthorization<TEntity, TCreateRequest, TUpdateRequest, TResponse, TManager, TKey>
        : BaseControllerWithCrdAuthorization<TEntity, TCreateRequest, TResponse, TManager, TKey> 
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>, IBusinessManagerUpdate<TEntity, TUpdateRequest, TKey>
    {

        protected BaseControllerWithCrudAuthorization(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        : base(manager, localizationService, logger, mapper)
        {

        }

        protected async Task<IActionResult> BaseUpdate(TKey id, [FromBody] TUpdateRequest request)
        {
            var result = await Manager.UpdateAsync(id, request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}