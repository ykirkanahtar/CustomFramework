﻿namespace CustomFramework.WebApiUtils.Authorization.Contracts.Requests
{
    public class EntityClaimRequest
    {
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
