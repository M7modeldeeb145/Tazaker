namespace Tazaker.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public League? League { get; set; }
        public Stadium? Stadium { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
