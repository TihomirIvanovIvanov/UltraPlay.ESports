using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface ISportService
    {
        Task AddOrUpdateSportAsync(XmlSportDto xmlSport);
    }
}
