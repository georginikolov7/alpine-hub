using Microsoft.AspNetCore.Mvc;

using AlpineHub.Core.Contracts.Lift;
using AlpineHub.Core.ViewModels.Lift;

namespace AlpineHub.Web.Controllers
{
    public class LiftController(ILogger<LiftController> logger, ILiftService liftService) : BaseController(logger)
    {
        public async Task<IActionResult> Index()
        {
            var model = await liftService.GetAllLiftsDetailsAsync();
            return View(model);
        }

        public async Task<IActionResult> GetLiftById(string id)
        {

            LiftDetailsViewModel? model = await liftService.GetLiftByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return PartialView("_LiftDetailsModal", model);
        }
    }
}
