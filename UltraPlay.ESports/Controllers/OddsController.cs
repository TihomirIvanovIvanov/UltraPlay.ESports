﻿using Microsoft.AspNetCore.Mvc;
using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Events.ServiceModels;

namespace UltraPlay.ESports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OddsController : ControllerBase
    {
        private readonly IOddEventService eventService;

        private readonly ILogger<OddsController> logger;

        public OddsController(IOddEventService eventService, ILogger<OddsController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpPost("UpdateOdd")]
        public async Task<IActionResult> UpdateOdd([FromBody] OddServiceModel message)
        {
            try
            {
                this.eventService.UpdateOdd(message);
                return Ok("Match updated successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in UpdateOdd: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DeleteOdd/{oddId}/{betId}")]
        public async Task<IActionResult> DeleteOdd(long oddId, long betId)
        {
            try
            {
                this.eventService.DeleteOdd(oddId, betId);
                return Ok("Match deleted successfully");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occur in DeleteOdd: {ex.Message}.");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
