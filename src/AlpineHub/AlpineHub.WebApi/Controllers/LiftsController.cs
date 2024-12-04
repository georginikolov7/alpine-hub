using AlpineHub.Core.Contracts;
using AlpineHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiftsController(ILiftService liftService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AllLiftsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllLiftsDto>? model = await liftService.GetAllLiftsForMapAsync();
            return Ok(model);
        }
    }
}
