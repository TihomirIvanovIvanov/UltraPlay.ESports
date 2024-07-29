using Microsoft.AspNetCore.Mvc;
using UltraPlay.ESports.DataProcessing.Contracts;

namespace UltraPlay.ESports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataPollingService pollingService;

        private readonly ILogger<DataController> logger;

        public DataController(IDataPollingService pollingService, ILogger<DataController> logger)
        {
            this.pollingService = pollingService;
            this.logger = logger;
        }

        [HttpPost("FetchAndSave")]
        public async Task<IActionResult> FetchAndSaveData()
        {
            try
            {
                await this.pollingService.FetchAndSaveDataAsync();
                return Ok($"Data fetched and saved successfully.");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in DataController: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
