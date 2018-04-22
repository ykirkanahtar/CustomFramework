using System;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Constants;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Business
{
    public abstract class BaseBusinessManager
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly ILogger<BaseBusinessManager> Logger;
        protected readonly IMapper Mapper;

        protected BaseBusinessManager(IUnitOfWork unitOfWork, ILogger<BaseBusinessManager> logger, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Logger = logger;
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
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task<T> CommonOperationAsync<T>(Func<Task<T>> func
                                                        , BusinessBaseRequest businessBaseRequest
                                                        , BusinessUtilMethod businessUtilMethod
                                                        , string additionalInfo
                                                        , bool critical = false)
        {
            try
            {
                var result = await func.Invoke();
                BusinessUtil.Execute(businessUtilMethod, result, additionalInfo, critical);

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }

        protected async Task<T> CommonOperationWithTransactionAsync<T>(Func<Task<T>> func, BusinessBaseRequest businessBaseRequest)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = await func.Invoke();
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                    throw;
                }
            }
        }

        protected async Task CommonOperationWithTransactionAsync(Func<Task> func, BusinessBaseRequest businessBaseRequest)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await func.Invoke();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(0, ex, $"{DefaultResponseMessages.AnErrorHasOccured} - {ex.Message}");
                throw;
            }
        }
    }
}