using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface IBetService
    {
        Task AddOrUpdateBetAsync(XmlBetDto xmlBet, long matchId);
    }
}
