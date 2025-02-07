using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static AlpineHub.Data.Constants.CustomClaims;

namespace AlpineHub.Web.Controllers.Manager
{
    [Authorize(Policy = ManagerPolicyName)]
    public class ManagerController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
