using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlpineHub.Core.ViewModels.Slope;
using static AlpineHub.Common.ErrorMessages;
using static AlpineHub.Data.Constants.CustomClaims;
using AlpineHub.Core.Contracts.Slope;

namespace AlpineHub.Web.Controllers.Manager
{
    [Authorize(Policy = ManagerPolicyName)]
    public class ManageSlopesController(ILogger<ManageSlopesController> _logger, IManageableSlopeService slopeService) : BaseController(_logger)
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SlopeDetailsViewModel> model = await slopeService.GetAllManagerSlopesAsync();

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
                return RedirectToAction(nameof(Index));
            }          
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditSlope(string? id)
        {
            string? userId = GetUserId();
            try
            {
                EditSlopeFormModel model = await slopeService.GetSlopeForEditAsync(id);
                return View(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return View(model);
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
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteSlope(DeleteSlopeViewModel model)
        {
            try
            {
                await slopeService.DeleteSlopeAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
