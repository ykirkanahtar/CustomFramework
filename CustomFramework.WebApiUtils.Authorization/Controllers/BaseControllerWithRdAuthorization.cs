using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Controllers;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    public abstract class BaseControllerWithRdAuthorization<TEntity, TResponse, TManager, TKey> : BaseController
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TKey>
    {
        protected readonly TManager Manager;

        protected BaseControllerWithRdAuthorization(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        : base(localizationService, logger, mapper)
        {
            Manager = manager;
        }

        protected Task<IActionResult> BaseDeleteAsync(TKey id)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                await Manager.DeleteAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
            });
        }

        protected Task<IActionResult> BaseGetByIdAsync(TKey id)
        {
            return CommonOperationAsync<IActionResult>(async () =>
            {
                var result = await Manager.GetByIdAsync(id);
                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
            });
        }
    }
}