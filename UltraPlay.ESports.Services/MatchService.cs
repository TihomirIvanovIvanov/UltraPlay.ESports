using Microsoft.EntityFrameworkCore;
using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;
using UltraPlay.ESports.Services.ViewModels.Bets;
using UltraPlay.ESports.Services.ViewModels.Matches;
using UltraPlay.ESports.Services.ViewModels.Odds;

namespace UltraPlay.ESports.Services
{
    public class MatchService : IMatchService
    {
        private readonly ESportsDbContext dbContext;

        private readonly IBetService betService;

        private readonly string[] previewBetTypes = { "Match Winner", "Map Advantage", "Total Maps Played" };

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
                // CurrentValues.SetValues(xmlMatch) cannot handle Enum mapping so i do it manually
                existingMatch.Id = xmlMatch.Id;
                existingMatch.Name = xmlMatch.Name;
                existingMatch.StartDate = xmlMatch.StartDate;
                existingMatch.MatchType = Enum.TryParse(xmlMatch.MatchType, out Data.Models.Enums.MatchType matchType) ? matchType : Data.Models.Enums.MatchType.None;
                existingMatch.EventId = eventId;
                this.dbContext.Matches.Update(existingMatch);
            }

            foreach (var xmlBet in xmlMatch.Bets)
            {
                await this.betService.AddOrUpdateBetAsync(xmlBet, xmlMatch.Id);
            }
        }

        public async Task<IQueryable<MatchViewModel>> GetMatchesStartingInNext24HoursAsync()
        {
            var now = DateTime.UtcNow;
            var next24Hours = now.AddHours(24);

            var matches = await this.dbContext.Matches
                .Where(m => m.StartDate >= now && m.StartDate <= next24Hours)
                .Include(m => m.Bets)
                    .ThenInclude(b => b.Odds)
                .AsSplitQuery()
                .ToListAsync();

            var result = matches.Select(m => new MatchViewModel
            {
                Id = m.Id,
                Name = m.Name,
                StartDate = m.StartDate,
                ActiveBets = m.Bets
                   .Where(b => this.previewBetTypes.Contains(b.Name)
                      && (b.Match.MatchType == Data.Models.Enums.MatchType.PreMatch
                       || b.Match.MatchType == Data.Models.Enums.MatchType.Live))
                   .Select(b => new BetViewModel
                   {
                       Id = m.Id,
                       Name = b.Name,
                       IsLive = b.IsLive,
                       ActiveOdds = b.Odds.Any(o => !o.SpecialBetValue.HasValue)
                            ? b.Odds
                            .Select(o => new OddViewModel
                            {
                                Id = o.Id,
                                Name = o.Name,
                                Value = o.Value,
                            }).ToList()
                            : b.Odds
                            .GroupBy(o => o.SpecialBetValue)
                            .Select(o => o.First())
                            .Select(o => new OddViewModel
                            {
                                Id = o.Id,
                                Name = o.Name,
                                Value = o.Value,
                                SpecialBetValue = o.SpecialBetValue.HasValue && o.SpecialBetValue.Value != default(double)
                                                ? o.SpecialBetValue.Value : null,
                            }).ToList()
                   }).ToList()
            }).AsQueryable();

            return result;
        }

        public async Task<MatchDetailsViewModel> GetMatchByIdAsync(long id)
        {
            var match = await this.dbContext.Matches
                .Include(m => m.Bets)
                    .ThenInclude(b => b.Odds)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return null;
            }

            var matchDetails = new MatchDetailsViewModel
            {
                Id = match.Id,
                Name = match.Name,
                StartDate = match.StartDate,
                ActiveBets = match.Bets
                    .Where(b => this.previewBetTypes.Contains(b.Name) 
                       && (b.Match.MatchType == Data.Models.Enums.MatchType.PreMatch
                        || b.Match.MatchType == Data.Models.Enums.MatchType.Live))
                    .Select(b => new BetViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        ActiveOdds = b.Odds
                            .Select(o => new OddViewModel
                            {
                                Id = o.Id,
                                Name = o.Name,
                                Value = o.Value,
                                SpecialBetValue = o.SpecialBetValue.HasValue && o.SpecialBetValue.Value != default(double) 
                                                ? o.SpecialBetValue.Value : null,
                            }).ToList()
                    }).ToList(),
                InactiveBets = match.Bets
                    .Select(b => new BetViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        ActiveOdds = b.Odds
                            .Select(o => new OddViewModel
                            {
                                Id = o.Id,
                                Name = o.Name,
                                Value = o.Value,
                                SpecialBetValue = o.SpecialBetValue.HasValue && o.SpecialBetValue.Value != default(double)
                                                ? o.SpecialBetValue.Value : null,
                            }).ToList()
                    }).ToList()
            };

            return matchDetails;
        }
    }
}
