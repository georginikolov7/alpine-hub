namespace AlpineHub.Web.Areas.Admin.Controllers
{
    using AlpineHub.Core.Contracts;
    using AlpineHub.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static AlpineHub.Common.ApplicationConstants;

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController(ILogger<HomeController> _logger, IUserService userService) : BaseController(_logger)
    {
        public async Task<IActionResult> Index()
        {
            var model = await userService.GetUserCounts();
            return View(model);
        }
    }
}
