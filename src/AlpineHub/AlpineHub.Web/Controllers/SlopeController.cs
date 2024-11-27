using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class SlopeController(ILogger<SlopeController> logger, ISlopeService slopeService) : BaseController(logger)
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllSlopesViewModel> model = await slopeService.GetAllSlopes();
            return View(model);
        }
    }
}
