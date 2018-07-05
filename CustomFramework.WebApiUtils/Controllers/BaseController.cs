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
    }
}