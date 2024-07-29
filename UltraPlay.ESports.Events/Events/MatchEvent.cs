namespace UltraPlay.ESports.Events.Events
{
    public class MatchEvent
    {
        public long Id { get; set; }

        public string UpdateType { get; set; }

        public DateTime Timestamp { get; set; }

        // Add rest of the needed props
    }
}
