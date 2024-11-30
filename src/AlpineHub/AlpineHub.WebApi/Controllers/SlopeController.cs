using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlopeController(ISlopeService slopeService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IEnumerable<SlopeDetailsDTO> GetSlopeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
