namespace UltraPlay.ESports.Data.Models
{
    public class Odd : Model
    {
        public double Value { get; set; }

        public double? SpecialBetValue { get; set; }

        public long BetId { get; set; }

        public Bet Bet { get; set; }
    }
}
