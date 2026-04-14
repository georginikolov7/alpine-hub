using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlpineHub.Web.Controllers
{

    public abstract class BaseController : Controller
    {
        protected readonly ILogger logger;
        protected BaseController(ILogger _logger)
        {
            logger = _logger;
        }
        protected string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
