using System;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Identity.Controllers
{
    public abstract class BaseControllerWithCrudAuthorization<TEntity, TCreateRequest, TUpdateRequest, TResponse, TManager, TKey>
         : BaseControllerWithCrdAuthorization<TEntity, TCreateRequest, TResponse, TManager, TKey>
         where TEntity : BaseModel<TKey>
         where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>, IBusinessManagerUpdate<TEntity, TUpdateRequest, TKey>
    {
        protected BaseControllerWithCrudAuthorization(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, TManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        protected Task<IActionResult> BaseUpdateAsync(TKey id, [FromBody] TUpdateRequest request)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                if (!ModelState.IsValid)
                    throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));

                var result = await Manager.UpdateAsync(id, request);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
            });
        }
    }
}