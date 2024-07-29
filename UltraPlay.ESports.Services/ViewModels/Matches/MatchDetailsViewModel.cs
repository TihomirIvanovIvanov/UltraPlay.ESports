using UltraPlay.ESports.Services.ViewModels.Bets;

namespace UltraPlay.ESports.Services.ViewModels.Matches
{
    public class MatchDetailsViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public List<BetViewModel> ActiveBets { get; set; }

        public List<BetViewModel> InactiveBets { get; set; }
    }
}
