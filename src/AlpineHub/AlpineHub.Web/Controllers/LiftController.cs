using AlpineHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class LiftController(ILogger<LiftController> logger, ILiftService liftService) : BaseController(logger)
    {

        public async Task<IActionResult> Index()
        {
            var model = await liftService.GetAllLifts();
            return View(model);
        }
    }
}
