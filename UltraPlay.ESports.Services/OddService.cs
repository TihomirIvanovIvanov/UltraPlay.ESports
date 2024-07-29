using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services
{
    public class OddService : IOddService
    {
        private readonly ESportsDbContext dbContext;

        public OddService(ESportsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddOrUpdateOddAsync(XmlOddDto xmlOdd, long betId)
        {
            var existingOdd = await this.dbContext.Odds.FindAsync(xmlOdd.Id);

            if (existingOdd == null)
            {
                var newOdd = new Odd
                {
                    Id = xmlOdd.Id,
                    Name = xmlOdd.Name,
                    Value = xmlOdd.Value,
                    BetId = betId,
                    SpecialBetValue = xmlOdd.SpecialBetValue,
                };

                await this.dbContext.Odds.AddAsync(newOdd);
            }
            else
            {
                this.dbContext.Entry(existingOdd).CurrentValues.SetValues(xmlOdd);
            }
        }
    }
}
