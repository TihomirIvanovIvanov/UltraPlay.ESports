using Microsoft.Extensions.Logging;
using Moq;
using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.DataProcessing;
using UltraPlay.ESports.DataProcessing.Contracts;
using UltraPlay.ESports.Services.Contracts;

namespace UltraPlay.ESports.Tests.Common
{
    public abstract class BaseTest
    {
        protected readonly ESportsDbContext dbContext;
        protected readonly Mock<IXmlFetcherService> xmlFetcherService;
        protected readonly Mock<IDataSaverService> dataSaverService;
        protected readonly Mock<ILogger<DataSaverService>> saverLogger;
        protected readonly Mock<ILogger<DataPollingService>> poolingLogger;
        protected readonly Mock<IDataPollingService> pollingServiceMock;
        protected readonly Mock<ISportService> sportServiceMock;
        protected readonly Mock<IEventService> eventServiceMock;
        protected readonly Mock<IMatchService> matchServiceMock;
        protected readonly Mock<IBetService> betServiceMock;
        protected readonly Mock<IOddService> oddServiceMock;

        protected BaseTest()
        {
            this.dbContext = ESportsDbContextFactory.CreateInMemoryDbContext();
            this.xmlFetcherService = new Mock<IXmlFetcherService>();
            this.dataSaverService = new Mock<IDataSaverService>();
            this.saverLogger = new Mock<ILogger<DataSaverService>>();
            this.poolingLogger = new Mock<ILogger<DataPollingService>>();
            this.pollingServiceMock = new Mock<IDataPollingService>();
            this.sportServiceMock = new Mock<ISportService>();
            this.eventServiceMock = new Mock<IEventService>();
            this.matchServiceMock = new Mock<IMatchService>();
            this.betServiceMock = new Mock<IBetService>();
            this.oddServiceMock = new Mock<IOddService>();
        }

        protected void SeedData(ESportsDbContext dbContext)
        {
            var odd = new Odd
            {
                Id = 1,
                Name = "1",
                Value = 4.30,
                SpecialBetValue = null,
                Bet = new Bet
                {
                    Id = 1,
                    Name = "Match Winner",
                    IsLive = false,
                    Match = new Data.Models.Match
                    {
                        Id = 1,
                        Name = "beastcoast - Team Liquid",
                        MatchType = Data.Models.Enums.MatchType.PreMatch,
                        StartDate = DateTime.UtcNow,
                        Event = new Event
                        {
                            Id = 1,
                            Name = "Dota 2, Elite League",
                            CategoryId = 1,
                            IsLive = false,
                            Sport = new Sport
                            {
                                Id = 1,
                                Name = "eSports",
                            }
                        }
                    }
                }
            };

            var odd2 = new Odd
            {
                Id = 2,
                Name = "2",
                Value = 3.80,
                SpecialBetValue = -1.5,
                Bet = new Bet
                {
                    Id = 2,
                    Name = "Map Advantage",
                    IsLive = false,
                    Match = new Data.Models.Match
                    {
                        Id = 2,
                        Name = "nouns - Shopify Rebellion",
                        MatchType = Data.Models.Enums.MatchType.PreMatch,
                        StartDate = DateTime.UtcNow,
                        Event = new Event
                        {
                            Id = 2,
                            Name = "Dota 2, Elite League",
                            CategoryId = 2,
                            IsLive = false,
                            Sport = new Sport
                            {
                                Id = 2,
                                Name = "eSports",
                            }
                        }
                    }
                }
            };

            this.dbContext.AddRange(odd, odd2);
            this.dbContext.SaveChanges();
        }
    }
}
