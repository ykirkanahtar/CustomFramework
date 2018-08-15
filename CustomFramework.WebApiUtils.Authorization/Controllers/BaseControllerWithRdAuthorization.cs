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
    public abstract class BaseControllerWithRdAuthorization<TEntity, TResponse, TManager, TKey> : Controller
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TKey>
    {
        protected readonly TManager Manager;
        protected readonly ILocalizationService LocalizationService;
        protected readonly ILogger<Controller> Logger;
        protected readonly IMapper Mapper;

        protected BaseControllerWithRdAuthorization(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        {
            Manager = manager;
            LocalizationService = localizationService;
            Logger = logger;
            Mapper = mapper;
        }

        protected async Task<IActionResult> BaseDelete(TKey id)
        {
            await Manager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        protected async Task<IActionResult> BaseGetById(TKey id)
        {
            var result = await Manager.GetByIdAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}