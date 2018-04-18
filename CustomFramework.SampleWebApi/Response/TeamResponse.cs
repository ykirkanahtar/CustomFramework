using System.Collections.Generic;
using Newtonsoft.Json;

namespace CustomFramework.SampleWebApi.Response
{
    public class TeamResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public virtual ICollection<MatchResponse> HomeMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<MatchResponse> AwayMatches { get; set; }

        [JsonIgnore]
        public virtual ICollection<StatResponse> Stats { get; set; }
    }
}
