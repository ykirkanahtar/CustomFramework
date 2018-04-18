using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CustomFramework.Data;
using Newtonsoft.Json;

namespace CustomFramework.SampleWebApi.Models
{
    public class Match : BaseModel<int>
    {
        private DateTime _matchDateTime;

        public DateTime MatchDate
        {
            get => _matchDateTime;
            set => _matchDateTime = value.Date;
        }

        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string VideoLink { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }

    }
}
