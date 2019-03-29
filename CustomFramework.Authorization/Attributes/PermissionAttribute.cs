using System;
using CustomFramework.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace CustomFramework.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string Entity { get; set; }

        public string CustomClaim { get; set; }

        public Crud? Crud { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public PermissionAttribute(string customClaim) : base("Permission")
        {
            CustomClaim = customClaim;
        }

        [JsonConstructor]
        public PermissionAttribute(string entity, Crud crud) : base("Permission")
        {
            Entity = entity;
            Crud = crud;
        }

        public PermissionAttribute(string claimType, string claimValue) : base("Permission")
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
    }
}