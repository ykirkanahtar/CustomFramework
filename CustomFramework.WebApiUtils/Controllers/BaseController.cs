using AutoMapper;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseController: Controller
    {
        protected readonly ILocalizationService LocalizationService;
        protected readonly ILogger<Controller> Logger;
        protected readonly IMapper Mapper;

        protected BaseController(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        {
            LocalizationService = localizationService;
            Logger = logger;
            Mapper = mapper;
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await func.Invoke();
                scope.Complete();
                return result;
            }
        }
    }
}