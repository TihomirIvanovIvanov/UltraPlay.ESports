namespace UltraPlay.ESports.Events.Events
{
    public class BetEvent
    {
        public long Id { get; set; }

        public long MatchId { get; set; }

        public string UpdateType { get; set; }

        public DateTime Timestamp { get; set; }

        // Add rest of the needed props
    }
}
