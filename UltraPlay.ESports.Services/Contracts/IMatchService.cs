using UltraPlay.ESports.Services.Dto;
using UltraPlay.ESports.Services.ViewModels.Matches;

namespace UltraPlay.ESports.Services.Contracts
{
    public interface IMatchService
    {
        Task AddOrUpdateMatchAsync(XmlMatchDto xmlMatch, long eventId);

        Task<IQueryable<MatchViewModel>> GetMatchesStartingInNext24HoursAsync();

        Task<MatchDetailsViewModel> GetMatchByIdAsync(long id);
    }
}
