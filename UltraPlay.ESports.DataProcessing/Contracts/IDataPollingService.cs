namespace UltraPlay.ESports.DataProcessing.Contracts
{
    public interface IDataPollingService
    {
        Task FetchAndSaveDataAsync();
    }
}
