using AutoMapper;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomFramework.WebApiUtils.Business
{
    public abstract class BaseBusinessManager
    {
        protected readonly ILogger<BaseBusinessManager> Logger;
        protected readonly IMapper Mapper;

        protected BaseBusinessManager(ILogger<BaseBusinessManager> logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                T result = await func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
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
                T result = await func.Invoke();
                BusinessUtil.Execute(businessUtilMethod, result, additionalInfo);

                return result;
            }
            catch (Exception ex)
            {
                //TODO : ex.Message string değilse hataya yol açıyor daha genel bir çözüm bul
                //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
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
                T result = func.Invoke();
                BusinessUtil.Execute(businessUtilMethod, result, additionalInfo);

                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected T CommonOperation<T>(Func<T> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                T result = func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }


        protected async Task<T> CommonOperationWithTransactionAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    T result = await func.Invoke();
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                    throw;
                }
            }
        }

        protected async Task CommonOperationWithTransactionAsync(Func<Task> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await func.Invoke();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }
    }
}