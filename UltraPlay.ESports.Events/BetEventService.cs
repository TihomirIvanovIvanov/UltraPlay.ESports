using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.EventQueues;
using UltraPlay.ESports.Events.Events;
using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events
{
    public class BetEventService : IBetEventService
    {
        public void DeleteBet(long betId, long matchId)
        {
            var eventMessage = new BetEvent
            {
                Id = betId,
                MatchId = matchId,
                UpdateType = "Delete",
                Timestamp = DateTime.UtcNow
            };
            BetEventQueue.TryDequeueBet(out eventMessage);
        }

        public void UpdateBet(BetServiceModel bet)
        {
            var eventMessage = new BetEvent
            {
                Id = bet.Id,
                MatchId = bet.MatchId,
                UpdateType = "Update",
                Timestamp = DateTime.UtcNow
            };
            BetEventQueue.EnqueueBet(eventMessage);
        }
    }
}
