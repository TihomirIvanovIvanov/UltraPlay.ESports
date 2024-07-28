using Microsoft.Extensions.Logging;
using System.Xml.Serialization;
using UltraPlay.ESports.DataProcessing.Contracts;
using UltraPlay.ESports.Services.Contracts;
using UltraPlay.ESports.Services.Dto;

namespace UltraPlay.ESports.DataProcessing
{
    public class DataSaverService : IDataSaverService
    {
        private readonly ISportService sportService;

        private readonly ILogger<DataSaverService> logger;

        public DataSaverService(ISportService sportService, ILogger<DataSaverService> logger)
        {
            this.sportService = sportService;
            this.logger = logger;
        }

        public async Task SaveDataAsync(string xmlData)
        {
            try
            {
                var xmlSports = this.ConvertXmlToModels(xmlData);

                foreach (var xmlSport in xmlSports.Sports)
                {
                    await this.sportService.AddOrUpdateSportAsync(xmlSport);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while saving data in DataSaverService.");
                throw;
            }
        }        

        private XmlSportsDto ConvertXmlToModels(string xmlData)
        {
            var serializer = new XmlSerializer(typeof(XmlSportsDto));
            using (var reader = new StringReader(xmlData))
            {
                var xmlSports = (XmlSportsDto)serializer.Deserialize(reader);
                return xmlSports;
            }
        }
    }
}
