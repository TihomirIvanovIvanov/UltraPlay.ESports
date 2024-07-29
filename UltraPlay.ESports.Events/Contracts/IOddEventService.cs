using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events.Contracts
{
    public interface IOddEventService
    {
        void UpdateOdd(OddServiceModel odd);

        void DeleteOdd(long oddId, long betId);
    }
}
