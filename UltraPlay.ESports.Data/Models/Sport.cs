namespace UltraPlay.ESports.Data.Models
{
    public class Sport : Model
    {
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
