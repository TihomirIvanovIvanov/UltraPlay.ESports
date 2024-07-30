using Microsoft.AspNetCore.Mvc;
using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly IBetEventService eventService;

        private readonly ILogger<BetsController> logger;

        public BetsController(IBetEventService eventService, ILogger<BetsController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpPost("UpdateBet")]
        public async Task<IActionResult> UpdateBet([FromBody] BetServiceModel message)
        {
            try
            {
                this.eventService.UpdateBet(message);
                return Ok("Bet updated successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in UpdateBet: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DeleteBet/{betId}/{matchId}")]
        public async Task<IActionResult> DeleteBet(long betId, long matchId)
        {
            try
            {
                this.eventService.DeleteBet(betId, matchId);
                return Ok("Bet deleted successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in DeleteBet: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
