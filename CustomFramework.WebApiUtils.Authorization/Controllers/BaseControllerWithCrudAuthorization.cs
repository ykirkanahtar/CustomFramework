using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

        protected Task<IActionResult> BaseUpdateAsync(TKey id, [FromBody] TUpdateRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
            });
        }
    }
}