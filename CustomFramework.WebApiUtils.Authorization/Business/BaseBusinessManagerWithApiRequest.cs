using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Business;
using Microsoft.Extensions.Logging;
using IApiRequestAccessor = CustomFramework.WebApiUtils.Authorization.Utils.IApiRequestAccessor;

namespace CustomFramework.WebApiUtils.Authorization.Business
{
    public class BaseBusinessManagerWithApiRequest<TApiRequest> : BaseBusinessManager
            where TApiRequest : IApiRequest
    {
        protected readonly IApiRequest ApiRequestAccessor;

        public BaseBusinessManagerWithApiRequest(IUnitOfWork unitOfWork, ILogger<BaseBusinessManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper)
        {
            ApiRequestAccessor = apiRequestAccessor.GetApiRequest<TApiRequest>();
        }
    }
}