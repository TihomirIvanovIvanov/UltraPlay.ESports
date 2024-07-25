namespace UltraPlay.ESports.Data.Models
{
    public class Event : Model
    {
        public string Name { get; set; }

        public long SportId { get; set; }

        public Sport Sport { get; set; }

        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
