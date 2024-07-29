namespace UltraPlay.ESports.Events.ServiceModels
{
    public class OddServiceModel
    {
        public long Id { get; set; }

        public long BetId { get; set; }

        public string UpdateType { get; set; }

        public DateTime Timestamp { get; set; }

        // Add rest of the needed props
    }
}
