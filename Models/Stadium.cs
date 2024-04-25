namespace Tazaker.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public string Address { get; set; }=null!;
        public Team? team { get; set; }
        public List<Match>? Matches { get; set; }
    }
}
