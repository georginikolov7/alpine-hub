using AlpineHub.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlpineHub.Web.Controllers
{

    public abstract class BaseController : Controller
    {
        protected readonly ILogger logger;
        private readonly ICountersService countersService;
        protected BaseController(ILogger _logger, ICountersService _countersService)
        {
            countersService = _countersService;
            logger = _logger;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            //After exec:
            ViewBag.TotalLiftsCount = await countersService.GetTotalNumberOfLiftsAsync();
            ViewBag.TotalSlopesCount = await countersService.GetTotalNumberOfSlopesAsync();

            ViewBag.OpenLiftsCount = await countersService.GetNumberOfOpenLiftsAsync();
            ViewBag.OpenSlopesCount = await countersService.GetNumberOfOpenSlopesAsync();

        }
    }
}
