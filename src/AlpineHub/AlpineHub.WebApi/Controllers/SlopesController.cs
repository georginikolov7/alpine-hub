using AlpineHub.Core.Contracts.Slope;
using AlpineHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlopesController(ILogger<SlopesController> logger, ISlopeService slopeService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AllSlopesDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AllSlopesDto>? slopes = await slopeService.GetAllSlopesForMapAsync();
            return Ok(slopes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SlopeDetailsDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSlope(string? id)
        {
            try
            {
                SlopeDetailsDto dto = await slopeService.GetSlopeDetailsForMapAsync(id);
                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }
    }
}
