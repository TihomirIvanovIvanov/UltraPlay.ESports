namespace UltraPlay.ESports.DataProcessing.Contracts
{
    public interface IDataSaverService
    {
        Task SaveDataAsync(string xmlData);
    }
}
