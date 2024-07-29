using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events.Contracts
{
    public interface IBetEventService
    {
        void UpdateBet(BetServiceModel bet);

        void DeleteBet(long betId, long matchId);
    }
}
