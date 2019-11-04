using System;
using CustomFramework.Data.Contracts;

namespace CustomFramework.Data.Models
{
    public interface IBaseModelNonUser<TKey>
    {
        TKey Id { get; set; }
        DateTime CreateDateTime { get; set; }
        DateTime? UpdateDateTime { get; set; }
        DateTime? DeleteDateTime { get; set; }
        Status Status { get; set; }
    }
}