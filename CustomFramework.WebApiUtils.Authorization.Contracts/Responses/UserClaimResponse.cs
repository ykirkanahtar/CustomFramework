﻿namespace CustomFramework.WebApiUtils.Authorization.Contracts.Responses
{
    public class UserClaimResponse
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }
    }
}