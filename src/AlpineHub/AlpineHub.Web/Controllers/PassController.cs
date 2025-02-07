using Microsoft.AspNetCore.Mvc;

using AlpineHub.Core.Contracts.Pass;
using AlpineHub.Core.ViewModels.Pass;

namespace AlpineHub.Web.Controllers
{
    public class PassController(ILogger<PassController> _logger, IPassService passService) : BaseController(_logger)
    {
        [HttpGet]
        public async Task<IActionResult> Index(AllPassesSearchFilterViewModel inputModel)
        {
            AllPassesSearchFilterViewModel model = await passService.GetAllPassesAsync(inputModel);
            return View(model);
        }

        
    }
}
