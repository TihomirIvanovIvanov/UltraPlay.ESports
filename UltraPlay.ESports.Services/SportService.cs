using UltraPlay.ESports.Data;
using UltraPlay.ESports.Data.Models;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.Services
{
    public class SportService : ISportService
    {
        private readonly ESportsDbContext dbContext;

        private readonly IEventService eventService;

        public SportService(ESportsDbContext dbContext, IEventService eventService)
        {
            this.dbContext = dbContext;
            this.eventService = eventService;
        }

        public async Task AddOrUpdateSportAsync(XmlSportDto xmlSport)
        {
            var sport = new Sport
            {
                Id = xmlSport.Id,
                Name = xmlSport.Name,
            };

            var existingSport = await this.dbContext.Sports.FindAsync(sport.Id);
            if (existingSport == null)
            {
                await this.dbContext.Sports.AddAsync(sport);
            }
            else
            {
                this.dbContext.Entry(existingSport).CurrentValues.SetValues(sport);
            }

            foreach (var xmlEvent in xmlSport.Events)
            {
                await this.eventService.AddOrUpdateEventAsync(xmlEvent, sport.Id);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}