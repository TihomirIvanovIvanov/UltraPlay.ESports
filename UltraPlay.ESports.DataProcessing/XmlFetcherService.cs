using UltraPlay.ESports.DataProcessing.Contracts;

namespace UltraPlay.ESports.DataProcessing
{
    public class XmlFetcherService : IXmlFetcherService
    {
        private readonly HttpClient httpClient;

        private readonly string url = "https://sports.ultraplay.net/sportsxml?clientKey=80E2CA86-3F7E-4D82-936C-05CC05C24A2B&sportId=2357&days=7";

        public XmlFetcherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> FetchXmlDataAsync()
        {
            var response = await this.httpClient.GetAsync(this.url);
            var xmlAsString = await response.Content.ReadAsStringAsync();
            return xmlAsString;
        }        
    }
}
