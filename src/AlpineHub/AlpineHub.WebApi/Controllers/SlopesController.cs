using AlpineHub.Core.Contracts;
using AlpineHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlopesController(ISlopeService slopeService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AllSlopesDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AllSlopesDto>? slopes = await slopeService.GetAllSlopesForMapAsync();
            return Ok(slopes);
        }
    }
}
