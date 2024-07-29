using System.Collections.Concurrent;
using UltraPlay.ESports.Events.Events;

namespace UltraPlay.ESports.Events.EventQueues
{
    public static class OddEventQueue
    {
        private static readonly ConcurrentQueue<OddEvent> events = new ConcurrentQueue<OddEvent>();

        public static void EnqueueOdd(OddEvent eventMessage)
        {
            events.Enqueue(eventMessage);
        }

        public static bool TryDequeueOdd(out OddEvent eventMessage)
        {
            return events.TryDequeue(out eventMessage);
        }
    }
}
