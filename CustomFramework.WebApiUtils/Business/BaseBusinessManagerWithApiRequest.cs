using AutoMapper;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Business
{
    public abstract class BaseBusinessManagerWithApiRequest<TApiRequest> : BaseBusinessManager
            where TApiRequest : IApiRequest
    {
        private readonly IApiRequest _apiRequestAccessor;

        protected BaseBusinessManagerWithApiRequest(ILogger<BaseBusinessManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper)
        {
            _apiRequestAccessor = apiRequestAccessor.GetApiRequest<TApiRequest>();
        }

        protected int GetLoggedInUserId()
        {
            return _apiRequestAccessor.UserId;
        }
    }
}