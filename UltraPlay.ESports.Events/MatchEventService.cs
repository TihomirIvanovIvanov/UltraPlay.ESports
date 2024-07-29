using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.EventQueues;
using UltraPlay.ESports.Events.Events;
using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events
{
    public class MatchEventService : IMatchEventService
    {
        public void DeleteMatch(long id)
        {
            var eventMessage = new MatchEvent
            {
                Id = id,
                UpdateType = "Delete",
                Timestamp = DateTime.UtcNow
            };
            MatchEventQueue.TryDequeueMatch(out eventMessage);
        }

        public void UpdateMatch(MatchServiceModel match)
        {
            var eventMessage = new MatchEvent
            {
                Id = match.Id,
                UpdateType = "Update",
                Timestamp = DateTime.UtcNow
            };
            MatchEventQueue.EnqueueMatch(eventMessage);
        }
    }
}
