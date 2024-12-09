namespace AlpineHub.Web.Controllers.Manager
{
    using AlpineHub.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AlpineHub.Data.Constants.CustomClaims;
    using static AlpineHub.Common.ErrorMessages;
    using AlpineHub.Core.ViewModels.Lift;
    using AlpineHub.Web.Controllers;

    [Authorize(Policy = ManagerPolicyName)]
    public class ManagerController(ILogger<ManagerController> _logger, IManageableSlopeService slopeService, IManageableLiftService liftService) : BaseController(_logger)
    {
        public IActionResult Index()
        {
            return View();
        }
        
       
    }
}
