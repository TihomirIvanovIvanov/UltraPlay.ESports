namespace UltraPlay.ESports.Data.Models
{
    public class Bet : Model
    {
        public string Name { get; set; }

        public bool IsLive { get; set; }

        public long MatchId { get; set; }

        public Match Match { get; set; }

        public ICollection<Odd> Odds { get; set; } = new List<Odd>();
    }
}
