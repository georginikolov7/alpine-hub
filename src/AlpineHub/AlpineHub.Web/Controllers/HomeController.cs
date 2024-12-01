using AlpineHub.Core.Contracts;
using AlpineHub.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlpineHub.Web.Controllers
{
    public class HomeController(ILogger<HomeController> _logger, ICountersService countersService) : BaseController(_logger,countersService)
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
