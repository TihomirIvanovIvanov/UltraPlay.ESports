using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface IOddService
    {
        Task AddOrUpdateOddAsync(XmlOddDto xmlOdd, long betId);
    }
}
