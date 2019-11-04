using System;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;

namespace CustomFramework.Data.Models
{
    public abstract class BaseModelNonUser<TKey> : IBaseModelNonUser<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public Status Status { get; set; }
    }
}