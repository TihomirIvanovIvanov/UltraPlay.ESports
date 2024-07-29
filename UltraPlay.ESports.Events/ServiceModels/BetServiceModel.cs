namespace UltraPlay.ESports.Events.ServiceModels
{
    public class BetServiceModel
    {
        public long Id { get; set; }

        public long MatchId { get; set; }

        public string UpdateType { get; set; }

        public DateTime Timestamp { get; set; }

        // Add rest of the needed props
    }
}
