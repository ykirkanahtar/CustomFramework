﻿namespace CustomFramework.WebApiUtils.Authorization.Requests
{
    public class RoleClaimRequest
    {
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public int ClaimId { get; set; }
    }
}