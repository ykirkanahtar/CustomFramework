using AutoMapper;
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

        public BaseBusinessManagerWithApiRequest(ILogger<BaseBusinessManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper)
        {
            ApiRequestAccessor = apiRequestAccessor.GetApiRequest<TApiRequest>();
        }
    }
}