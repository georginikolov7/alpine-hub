
using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Pass;
using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class PassController(ILogger<PassController> _logger, IPassService passService) : BaseController(_logger)
    {
        [HttpGet]
        public async Task<IActionResult> Index(AllPassesSearchFilterViewModel inputModel)
        {
            AllPassesSearchFilterViewModel model = await passService.GetAllPasses(inputModel);
            return View(model);
        }

        
    }
}
