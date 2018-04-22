using System;
using CustomFramework.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;

namespace CustomFramework.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string Entity { get; set; }

        public CustomClaim? CustomClaim { get; set; }

        public Crud? Crud { get; set; }

        public PermissionAttribute(CustomClaim customClaim) : base("Permission")
        {
            CustomClaim = customClaim;
        }

        public PermissionAttribute(string entity, Crud crud) : base("Permission")
        {
            Entity = entity;
            Crud = crud;
        }
    }
}