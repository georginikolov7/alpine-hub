using Microsoft.AspNetCore.Mvc;

namespace AlpineHub.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ILogger logger;
        protected BaseController(ILogger _logger)
        {
            logger = _logger;
        }
    }
}
