using Microsoft.AspNetCore.Mvc;
using UltraPlay.ESports.DataProcessing.Contracts;

namespace UltraPlay.ESports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataPollingService pollingService;

        public DataController(IDataPollingService pollingService)
        {
            this.pollingService = pollingService;
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
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
