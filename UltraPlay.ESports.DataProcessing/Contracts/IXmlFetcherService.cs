namespace UltraPlay.ESports.DataProcessing.Contracts
{
    public interface IXmlFetcherService
    {
        Task<string> FetchXmlDataAsync();
    }
}
