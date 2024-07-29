using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.EventQueues;
using UltraPlay.ESports.Events.Events;
using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events
{
    public class OddEventService : IOddEventService
    {
        public void DeleteOdd(long oddId, long betId)
        {
            var eventMessage = new OddEvent
            {
                Id = oddId,
                BetId = betId,
                UpdateType = "Delete",
                Timestamp = DateTime.UtcNow
            };
            OddEventQueue.TryDequeueOdd(out eventMessage);
        }

        public void UpdateOdd(OddServiceModel odd)
        {
            var eventMessage = new OddEvent
            {
                Id = odd.Id,
                BetId = odd.BetId,
                UpdateType = "Update",
                Timestamp = DateTime.UtcNow
            };
            OddEventQueue.EnqueueOdd(eventMessage);
        }
    }
}
