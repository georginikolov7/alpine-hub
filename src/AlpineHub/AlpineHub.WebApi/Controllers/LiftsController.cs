using AlpineHub.Core.Contracts;
using AlpineHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiftsController(ILogger<LiftsController> logger, ILiftService liftService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AllLiftsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllLiftsDto>? model = await liftService.GetAllLiftsForMapAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(LiftDetailsDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLift(string? id)
        {
            try
            {
                LiftDetailsDto dto = await liftService.GetLiftDetailsForMapByIdAsync(id);
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
