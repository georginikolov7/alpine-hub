using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class SlopeController : BaseController
    {
        private readonly ISlopeService slopeService;

        public SlopeController(ISlopeService slopeService)
        {
            this.slopeService = slopeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllSlopesViewModel> model = await slopeService.GetAllSlopes();
            return View(model);
        }
    }
}
