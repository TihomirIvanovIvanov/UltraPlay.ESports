using Microsoft.Extensions.Logging;
using UltraPlay.ESports.DataProcessing.Contracts;

namespace UltraPlay.ESports.DataProcessing
{
    public class DataPollingService : IDataPollingService
    {
        private readonly IXmlFetcherService xmlFetcherService;

        private readonly IDataSaverService dataSaverService;

        private readonly ILogger<DataPollingService> logger;

        public DataPollingService(IXmlFetcherService xmlFetcherService, IDataSaverService dataSaverService, ILogger<DataPollingService> logger)
        {
            this.xmlFetcherService = xmlFetcherService;
            this.dataSaverService = dataSaverService;
            this.logger = logger;
        }

        public async Task FetchAndSaveDataAsync()
        {
            try
            {
                var xmlData = await this.xmlFetcherService.FetchXmlDataAsync();
                await this.dataSaverService.SaveDataAsync(xmlData);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching and saving data in DataPollingService.");
                throw;
            }           
        }
    }
}
