using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Events.Contracts
{
    public interface IMatchEventService
    {
        void UpdateMatch(MatchServiceModel match);

        void DeleteMatch(long id);
    }
}
