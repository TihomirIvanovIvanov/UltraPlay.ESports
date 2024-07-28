using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services
{
    public class EvenService : IEventService
    {
        private readonly ESportsDbContext dbContext;

        private readonly IMatchService matchService;

        public EvenService(ESportsDbContext dbContext, IMatchService matchService)
        {
            this.dbContext = dbContext;
            this.matchService = matchService;
        }

        public async Task AddOrUpdateEventAsync(XmlEventDto xmlEvent, long sportId)
        {
            var existingEvent = await this.dbContext.Events.FindAsync(xmlEvent.Id);

            if (existingEvent == null)
            {
                var newEvent = new Event
                {
                    Id = xmlEvent.Id,
                    Name = xmlEvent.Name,
                    SportId = sportId,
                    CategoryId = xmlEvent.CategoryId,
                    IsLive = xmlEvent.IsLive,
                };

                await this.dbContext.Events.AddAsync(newEvent);
            }
            else
            {
                this.dbContext.Entry(existingEvent).CurrentValues.SetValues(xmlEvent);
            }

            foreach (var xmlMatch in xmlEvent.Matches)
            {
                await this.matchService.AddOrUpdateMatchAsync(xmlMatch, xmlEvent.Id);
            }
        }
    }
}
