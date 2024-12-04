namespace AlpineHub.Web.Controllers
{
    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.ViewModels.Slope;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static AlpineHub.Web.Infrastructure.Constants.CustomClaims;
    using static AlpineHub.Common.EntityValidationMessages;
    using AlpineHub.Core.ViewModels.Lift;

    [Authorize(Policy = ManagerPolicyName)]
    public class ManagerController(ILogger<ManagerController> _logger, IManageableSlopeService slopeService, IManageableLiftService liftService) : BaseController(_logger)
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Slopes()
        {
            IEnumerable<SlopeDetailsViewModel> model = await slopeService.GetAllManagerSlopesAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Lifts()
        {
            IEnumerable<LiftDetailsViewModel> model = await liftService.GetAllManagerLiftsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddSlope()
        {
            AddSlopeFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddSlope(AddSlopeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                slopeService.AddSlopeAsync(model);
                return RedirectToAction(nameof(Slopes));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                ModelState.AddModelError(string.Empty, string.Format(UnexpectedError));
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditSlope(string id)
        {
            string? userId = GetUserId();
            try
            {
                EditSlopeFormModel model = await slopeService.GetSlopeForEditAsync(id);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Slopes));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditSlope(EditSlopeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await slopeService.EditSlopeAsync(model);
                return RedirectToAction(nameof(Slopes));
            }
            catch (ArgumentException ex)
            {
                //If id is invalid return to Slopes page
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Slopes));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                ModelState.AddModelError(string.Empty, string.Format(UnexpectedEditError, "Slope"));
                return this.View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSlope(string? id)
        {
            try
            {
                DeleteSlopeViewModel model = await slopeService.GetSlopeForDeleteAsync(id);
                return PartialView("_DeleteConfirmationModal", model);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Slopes));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Slopes));
            }

        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteSlope(DeleteSlopeViewModel model)
        {
            try
            {
                await slopeService.DeleteSlopeAsync(model);
                return RedirectToAction(nameof(Slopes));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Slopes));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Slopes));
            }
        }


    }
}
