namespace AlpineHub.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AlpineHub.Web.Infrastructure.Constants.CustomClaims;
    [Authorize(Policy = ManagerPolicyName)]
    public class ManagerController(ILogger<ManagerController> logger) : BaseController(logger)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
