namespace UltraPlay.ESports.Data.Models
{
    public class Match : Model
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public Enums.MatchType MatchType { get; set; }

        public long EventId { get; set; }

        public Event Event { get; set; }

        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}