namespace CustomFramework.SampleWebApi.Response
{
    public class StatResponse
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public decimal Goal { get; set; }
        public decimal OwnGoal { get; set; }
        public decimal Assist { get; set; }

        public virtual MatchResponse Match { get; set; }

        public virtual TeamResponse Team { get; set; }

        public virtual PlayerResponse Player { get; set; }
    }
}
