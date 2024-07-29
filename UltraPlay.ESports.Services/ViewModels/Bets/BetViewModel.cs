using UltraPlay.ESports.Services.ViewModels.Odds;

namespace UltraPlay.ESports.Services.ViewModels.Bets
{
    public class BetViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public List<OddViewModel> ActiveOdds { get; set; }
    }
}