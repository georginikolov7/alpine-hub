using AlpineHub.Core.Contracts.Slope;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class SlopeController(ILogger<SlopeController> logger, ISlopeService slopeService) : BaseController(logger)
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllSlopesViewModel> model = await slopeService.GetAllSlopesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetSlopeById(string id)
        {
            SlopeDetailsViewModel? model = await slopeService.GetSlopeByIdAsync(id);

            if (model == null)
            {
                //TODO: implement not found message
                return BadRequest();
            }
            return PartialView("_SlopeDetailsModal", model);
        }
    }
}
