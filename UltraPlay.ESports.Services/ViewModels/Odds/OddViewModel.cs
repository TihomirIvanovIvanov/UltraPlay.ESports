namespace UltraPlay.ESports.Services.ViewModels.Odds
{
    public class OddViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public double? SpecialBetValue { get; set; }
    }
}