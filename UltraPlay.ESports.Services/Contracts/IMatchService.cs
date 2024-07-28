using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface IMatchService
    {
        Task AddOrUpdateMatchAsync(XmlMatchDto xmlMatch, long eventId);
    }
}
