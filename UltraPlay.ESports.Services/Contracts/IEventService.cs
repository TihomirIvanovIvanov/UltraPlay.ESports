using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface IEventService
    {
        Task AddOrUpdateEventAsync(XmlEventDto xmlEvent, long sportId);
    }
}
