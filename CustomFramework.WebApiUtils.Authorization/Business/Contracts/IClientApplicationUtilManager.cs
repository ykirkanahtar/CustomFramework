﻿using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationUtilManager : IBusinessManager<ClientApplicationUtil, ClientApplicationUtilRequest, int>
                                                    , IBusinessManagerUpdate<ClientApplicationUtil, ClientApplicationUtilUpdateRequest, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}