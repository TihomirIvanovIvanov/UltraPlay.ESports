using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services
{
    public class BetService : IBetService
    {
        private readonly ESportsDbContext dbContext;

        private readonly IOddService oddService;

        public BetService(ESportsDbContext dbContext, IOddService oddService)
        {
            this.dbContext = dbContext;
            this.oddService = oddService;
        }

        public async Task AddOrUpdateBetAsync(XmlBetDto xmlBet, long matchId)
        {
            var existingBet = await this.dbContext.Bets.FindAsync(xmlBet.Id);

            if (existingBet == null)
            {
                var newBet = new Bet
                {
                    Id = xmlBet.Id,
                    Name = xmlBet.Name,
                    IsLive = xmlBet.IsLive,
                    MatchId = matchId,
                };

                await this.dbContext.Bets.AddAsync(newBet);
            }
            else
            {
                this.dbContext.Entry(existingBet).CurrentValues.SetValues(xmlBet);
            }

            foreach (var xmlOdd in xmlBet.Odds)
            {
                await this.oddService.AddOrUpdateOddAsync(xmlOdd, xmlBet.Id);
            }
        }
    }
}
