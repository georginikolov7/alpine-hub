using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public class MapController(ILogger<MapController> _logger) : BaseController(_logger)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
