namespace AlpineHub.Web.Areas.Admin.Controllers
{
    using AlpineHub.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static AlpineHub.Common.ApplicationConstants;

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController(ILogger<HomeController> _logger) : BaseController(_logger)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
