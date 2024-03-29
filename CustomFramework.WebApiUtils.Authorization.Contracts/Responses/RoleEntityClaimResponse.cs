﻿namespace CustomFramework.WebApiUtils.Authorization.Contracts.Responses
{
    public class RoleEntityClaimResponse
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
        public string Entity { get; set; }
        public bool CanSelect { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}