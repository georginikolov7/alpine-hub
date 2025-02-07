using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AlpineHub.Core.Contracts.Pass;
using AlpineHub.Core.ViewModels.PassPeriod;

using static AlpineHub.Data.Constants.CustomClaims;
using static AlpineHub.Common.ErrorMessages;

namespace AlpineHub.Web.Controllers.Manager
{
    [Authorize(Policy = ManagerPolicyName)]
    public class ManagePassPeriodsController(ILogger<ManagePassPeriodsController> _logger, IManageablePassPeriodService passPeriodService) : BaseController(_logger)
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<PeriodViewModel> model = await passPeriodService.GetAllPeriods();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPeriod()
        {
            AddPeriodFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPeriod(AddPeriodFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
               await  passPeriodService.AddPeriodAsync(model);
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
        public async Task<IActionResult> EditPeriod(string? id)
        {
            string? userId = GetUserId();
            try
            {
                EditPeriodFormModel model = await passPeriodService.GetPeriodForEditAsync(id);
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
        public async Task<IActionResult> EditPeriod(EditPeriodFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await passPeriodService.EditPeriodAsync(model);
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
        public async Task<IActionResult> DeletePeriod(string? id)
        {
            try
            {
                DeletePeriodViewModel model = await passPeriodService.GetPeriodForDeleteAsync(id);
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
        public async Task<IActionResult> ConfirmDeletePeriod(DeletePeriodViewModel model)
        {
            try
            {
                await passPeriodService.DeletePeriodAsync(model);
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
