using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.ServiceModels;
using UltraPlay.ESports.Services.Contracts;

namespace UltraPlay.ESports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService matchService;

        private readonly IMatchEventService eventService;

        private readonly ILogger<MatchesController> logger;

        public MatchesController(IMatchService matchService, IMatchEventService eventService, ILogger<MatchesController> logger)
        {
            this.matchService = matchService;
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpGet("StartingInNext24Hours")]
        public async Task<IActionResult> GetMatchesStartingInNext24Hours()
        {
            try
            {
                var matches = await this.matchService.GetMatchesStartingInNext24HoursAsync();
                var result = matches.ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in GetMatchesStartingInNext24Hours: {ex.Message}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetMatchById/{id}")]
        public async Task<IActionResult> GetMatchById(long id)
        {
            try
            {
                var match = await this.matchService.GetMatchByIdAsync(id);
                if (match == null)
                {
                    return NotFound($"Match with ID {id} not found.");
                }

                return Ok(match);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in GetMatchByIdAsync: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("UpdateMatch")]
        public async Task<IActionResult> UpdateMatch([FromBody] MatchServiceModel message)
        {
            try
            {
                this.eventService.UpdateMatch(message);
                return Ok("Match updated successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in UpdateMatch: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DeleteMatch/{id}")]
        public async Task<IActionResult> DeleteMatch(long id)
        {
            try
            {
                this.eventService.DeleteMatch(id);
                return Ok("Match deleted successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in DeleteMatch: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
