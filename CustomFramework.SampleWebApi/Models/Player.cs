using System;
using System.Collections.Generic;
using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.SampleWebApi.Models
{
    public class Player : BaseModel<int>
    {
        private DateTime _birthDate;
        public string Name { get; set; }
        public string Surname { get; set; }
      
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value.Date;
        }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }
    }
}
