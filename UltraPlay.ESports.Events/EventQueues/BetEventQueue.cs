using System.Collections.Concurrent;
using UltraPlay.ESports.Events.Events;

namespace UltraPlay.ESports.Events.EventQueues
{
    public static class BetEventQueue
    {
        private static readonly ConcurrentQueue<BetEvent> events = new ConcurrentQueue<BetEvent>();

        public static void EnqueueBet(BetEvent eventMessage)
        {
            events.Enqueue(eventMessage);
        }

        public static bool TryDequeueBet(out BetEvent eventMessage)
        {
            return events.TryDequeue(out eventMessage);
        }
    }
}
