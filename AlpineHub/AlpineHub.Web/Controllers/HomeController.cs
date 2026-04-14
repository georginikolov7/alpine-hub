using Microsoft.AspNetCore.Mvc;

using AlpineHub.Web.Models;

namespace AlpineHub.Web.Controllers
{
    public class HomeController(ILogger<HomeController> _logger) : BaseController(_logger)
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            else if (statusCode == 404)
            {
                return View("Error404");
            }

            return View(new ErrorViewModel());
        }
    }
}
