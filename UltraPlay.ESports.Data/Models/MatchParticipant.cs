namespace UltraPlay.ESports.Data.Models
{
    public class MatchParticipant
    {
        public long MatchId { get; set; }

        public Match Match { get; set; }

        public long ParticipantId { get; set; }

        public Participant Participant { get; set; }
    }
}
