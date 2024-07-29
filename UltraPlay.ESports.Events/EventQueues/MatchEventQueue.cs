using System.Collections.Concurrent;
using UltraPlay.ESports.Events.Events;

namespace UltraPlay.ESports.Events.EventQueues
{
    public static class MatchEventQueue
    {
        private static readonly ConcurrentQueue<MatchEvent> events = new ConcurrentQueue<MatchEvent>();

        public static void EnqueueMatch(MatchEvent eventMessage)
        {
            events.Enqueue(eventMessage);
        }

        public static bool TryDequeueMatch(out MatchEvent eventMessage)
        {
            return events.TryDequeue(out eventMessage);
        }
    }
}
