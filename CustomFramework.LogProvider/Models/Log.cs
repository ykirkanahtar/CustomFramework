using System;
using CustomFramework.Data.Models;

namespace CustomFramework.LogProvider.Models
{
    public class Log : BaseModelNonUser<long>
    {
        public string Request { get; set; }
        public DateTime RequestTime { get; set; }
        public string Response { get; set; }
        public DateTime ResponseTime { get; set; }
        public int? LoggedUserId { get; set; }
    }
}