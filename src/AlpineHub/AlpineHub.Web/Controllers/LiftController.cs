using AlpineHub.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class LiftController : BaseController
    {
        private readonly ILiftService liftService;
        public LiftController(ILiftService liftService)
        {
            this.liftService = liftService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await liftService.GetAllLifts();
            return View(model);
        }
    }
}
