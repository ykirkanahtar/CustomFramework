using AutoMapper;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Transactions;
using CustomFramework.WebApiUtils.Constants;

namespace CustomFramework.WebApiUtils.Business
{
    public abstract class BaseBusinessManager
    {
        private readonly ILogger<BaseBusinessManager> _logger;
        protected readonly IMapper Mapper;

        protected BaseBusinessManager(ILogger<BaseBusinessManager> logger, IMapper mapper)
        {
            _logger = logger;
            Mapper = mapper;
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                var result = await func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func
                                                        , BusinessBaseRequest businessBaseRequest
                                                        , BusinessUtilMethod businessUtilMethod
                                                        , string additionalInfo)
        {
            try
            {
                var result = await func.Invoke();
                BusinessUtil.Execute(businessUtilMethod, result, additionalInfo);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task CommonOperationAsync(Func<Task> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                await func.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected T CommonOperation<T>(Func<T> func
            , BusinessBaseRequest businessBaseRequest
            , BusinessUtilMethod businessUtilMethod
            , string additionalInfo)
        {
            try
            {
                var result = func.Invoke();
                BusinessUtil.Execute(businessUtilMethod, result, additionalInfo);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected T CommonOperation<T>(Func<T> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                var result = func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }
    }
}