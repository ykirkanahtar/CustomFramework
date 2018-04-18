using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using IApiRequestAccessor = CustomFramework.WebApiUtils.Authorization.Utils.IApiRequestAccessor;

namespace CustomFramework.WebApiUtils.Authorization.Business
{
    public class BaseBusinessManagerWithApiRequest<TManager, TApiRequest> : BaseBusinessManager<TManager>
           where TManager : IBusinessManager
            where TApiRequest : IApiRequest
    {
        protected readonly IApiRequest ApiRequestAccessor;

        public BaseBusinessManagerWithApiRequest(IUnitOfWork unitOfWork, ILogger<TManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper)
        {
            ApiRequestAccessor = apiRequestAccessor.GetApiRequest<TApiRequest>();
        }
    }
}