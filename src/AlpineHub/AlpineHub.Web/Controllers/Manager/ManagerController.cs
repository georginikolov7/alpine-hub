using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static AlpineHub.Data.Constants.CustomClaims;

using AlpineHub.Web.Controllers;
using AlpineHub.Core.Contracts.Slope;
using AlpineHub.Core.Contracts.Lift;

namespace AlpineHub.Web.Controllers.Manager
{
    [Authorize(Policy = ManagerPolicyName)]
    public class ManagerController(ILogger<ManagerController> _logger, IManageableSlopeService slopeService, IManageableLiftService liftService) : BaseController(_logger)
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
