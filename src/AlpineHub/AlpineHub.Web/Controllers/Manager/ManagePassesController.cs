using AlpineHub.Core.Contracts.Pass;
using AlpineHub.Core.ViewModels.Pass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static AlpineHub.Common.ErrorMessages;
using static AlpineHub.Data.Constants.CustomClaims;

namespace AlpineHub.Web.Controllers.Manager
{
    [Authorize(Policy = ManagerPolicyName)]
    public class ManagePassesController(ILogger<ManagePassesController> _logger, IManageablePassService passService) : BaseController(_logger)
    {
        public async Task<IActionResult> Index()
        {
            var model = await passService.GetAllPassesAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPass()
        {
            AddPassFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPass(AddPassFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await passService.AddPassAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditPass(string? id)
        {
            try
            {
                EditPassFormModel model = await passService.GetPassForEditAsync(id);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditPass(EditPassFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await passService.EditPassAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeletePass(string? id)
        {
            try
            {
                DeletePassViewModel model = await passService.GetPassForDeleteAsync(id);
                return PartialView("_DeleteConfirmationModal", model);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeletePass(DeletePassViewModel model)
        {
            try
            {
                await passService.DeletePassAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
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
