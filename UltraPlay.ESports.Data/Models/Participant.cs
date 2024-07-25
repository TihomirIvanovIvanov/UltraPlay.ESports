namespace UltraPlay.ESports.Data.Models
{
    public class Participant : Model
    {
        public string Name { get; set; }

        public ICollection<MatchParticipant> MatchParticipants { get; set; } = new List<MatchParticipant>();
    }
}
