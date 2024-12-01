using AlpineHub.Core.Contracts;
using AlpineHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoCountersController(ILiftService liftService, ISlopeService slopeService) : ControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(CountersDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                int totalSlopesCount = await slopeService.GetTotalNumberOfSlopesAsync();
                int openSlopesCount = await slopeService.GetNumberOfOpenSlopesAsync();

                int totalLiftsCount = await liftService.GetTotalNumberOfLiftsAsync();
                int openLiftsCount = await liftService.GetNumberOfOpenLiftsAsync();

                return Ok(new CountersDto
                {
                    TotalSlopesCount = totalSlopesCount,
                    OpenSlopesCount = openSlopesCount,
                    TotalLiftsCount = totalLiftsCount,
                    OpenLiftsCount = openLiftsCount
                });
            }
            catch (Exception e)
            {
                return NotFound();
            }


        }
    }
}
