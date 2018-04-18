using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CustomFramework.SampleWebApi.Response
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string VideoLink { get; set; }

        public virtual TeamResponse HomeTeam { get; set; }
        public virtual TeamResponse AwayTeam { get; set; }

        [JsonIgnore]
        public virtual ICollection<StatResponse> Stats { get; set; }
    }
}
