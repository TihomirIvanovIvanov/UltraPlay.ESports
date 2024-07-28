using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UltraPlay.ESports.DataProcessing.Contracts;

namespace UltraPlay.ESports.DataProcessing
{
    public class DataPollingBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        private readonly ILogger<DataPollingBackgroundService> logger;

        public DataPollingBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<DataPollingBackgroundService> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var dataPollingService = scope.ServiceProvider.GetRequiredService<IDataPollingService>();
                        await dataPollingService.FetchAndSaveDataAsync();
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred in the DataPollingBackgroundService.");
                }
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
}
