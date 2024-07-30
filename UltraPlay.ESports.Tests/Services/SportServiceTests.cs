using Microsoft.Extensions.Logging;
using UltraPlay.ESports.DataProcessing;
using UltraPlay.ESports.Services;
using UltraPlay.ESports.Services.Dto;
using UltraPlay.ESports.Tests.Common;

namespace UltraPlay.ESports.Tests.Services
{
    public class SportServiceTests : BaseTest
    {
        private new readonly XmlFetcherService xmlFetcherService;
        private new readonly DataSaverService dataSaverService;
        private new readonly ILogger<DataSaverService> saverLogger;
        private readonly ILogger<DataPollingService> polingLogger;
        private readonly DataPollingService pollingService;
        private readonly OddService oddService;
        private readonly BetService betService;
        private readonly MatchService matchService;
        private readonly EventService eventService;
        private readonly SportService sportService;

        // first too much dependencies i dont think this is correct
        public SportServiceTests()
        {
            this.xmlFetcherService = new XmlFetcherService(new HttpClient());
            this.saverLogger = new Logger<DataSaverService>(new LoggerFactory());
            this.polingLogger = new Logger<DataPollingService>(new LoggerFactory());

            this.oddService = new OddService(base.dbContext);
            this.betService = new BetService(base.dbContext, this.oddService);
            this.matchService = new MatchService(base.dbContext, this.betService);
            this.eventService = new EventService(base.dbContext, this.matchService);
            this.sportService = new SportService(base.dbContext, this.eventService);

            this.dataSaverService = new DataSaverService(this.sportService, saverLogger);
            this.pollingService = new DataPollingService(this.xmlFetcherService, this.dataSaverService, this.polingLogger);
        }

        [Fact]
        public async Task AddOrUpdateSportAsync_ValidSport_CallsDbContextAddOrUpdate()
        {
            // arrange
            base.SeedData(dbContext);
            var sport = this.dbContext.Sports.First();
            
            // here i cannot just cast events explicitly
            var xmlSport = new XmlSportDto
            {
                Id = sport.Id,
                Name = sport.Name,
                Events = (List<XmlEventDto>)sport.Events, 
            };

            // act
            await sportService.AddOrUpdateSportAsync(xmlSport);

            // assert

        }
    }
}
