using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services
{
    public class MatchService : IMatchService
    {
        private readonly ESportsDbContext dbContext;

        private readonly IBetService betService;

        public MatchService(ESportsDbContext dbContext, IBetService betService)
        {
            this.dbContext = dbContext;
            this.betService = betService;
        }

        public async Task AddOrUpdateMatchAsync(XmlMatchDto xmlMatch, long eventId)
        {
            var existingMatch = await this.dbContext.Matches.FindAsync(xmlMatch.Id);

            if (existingMatch == null)
            {
                var newMatch = new Match
                {
                    Id = xmlMatch.Id,
                    Name = xmlMatch.Name,
                    StartDate = xmlMatch.StartDate,
                    MatchType = Enum.TryParse(xmlMatch.MatchType, out Data.Models.Enums.MatchType matchType) ? matchType : Data.Models.Enums.MatchType.None,
                    EventId = eventId,
                };

                await this.dbContext.Matches.AddAsync(newMatch);
            }
            else
            {
                this.dbContext.Entry(existingMatch).CurrentValues.SetValues(xmlMatch);
            }

            foreach (var xmlBet in xmlMatch.Bets)
            {
                await this.betService.AddOrUpdateBetAsync(xmlBet, xmlMatch.Id);
            }
        }
    }
}
