namespace AlpineHub.Web.Controllers.Manager
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AlpineHub.Core.ViewModels.Lift;
    using AlpineHub.Core.ViewModels.LiftType;
    using AlpineHub.Core.Contracts.Lift;

    using static AlpineHub.Common.ErrorMessages;
    using static AlpineHub.Data.Constants.CustomClaims;

    [Authorize(Policy = ManagerPolicyName)]
    public class ManageLiftsController(ILogger<ManageLiftsController> _logger, IManageableLiftService liftService) : BaseController(_logger)
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<LiftDetailsViewModel> model = await liftService.GetAllLiftsAsync();

            IEnumerable<DeleteLiftTypeViewModel>? liftTypesModel = await liftService.GetAllLiftTypesAsync();
            ViewBag.LiftTypes = liftTypesModel;
            return View(model);
        }

        [HttpGet]
        public IActionResult AddLiftType()
        {
            AddLiftTypeFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddLiftType(AddLiftTypeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await liftService.AddLiftTypeAsync(model);
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
        public async Task<IActionResult> EditLift(string id)
        {
            try
            {
                EditLiftFormModel model = await liftService.GetLiftForEditAsync(id);
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
        public async Task<IActionResult> EditLift(EditLiftFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await liftService.EditLiftAsync(model);
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
        public async Task<IActionResult> DeleteLiftType(string? id)
        {
            try
            {
                DeleteLiftTypeViewModel model = await liftService.GetLiftTypeForDeleteAsync(id);
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
        public async Task<IActionResult> ConfirmDeleteLift(DeleteLiftViewModel model)
        {
            try
            {
                await liftService.DeleteLiftAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public IActionResult AddLift()
        {
            AddLiftFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddLift(AddLiftFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await liftService.AddLiftAsync(model);
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
        public async Task<IActionResult> EditLiftType(string? id)
        {
            try
            {
                EditLiftTypeFormModel model = await liftService.GetLiftTypeForEditAsync(id);
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
        public async Task<IActionResult> EditLiftType(EditLiftTypeFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await liftService.EditLiftTypeAsync(model);
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
        public async Task<IActionResult> DeleteLift(string? id)
        {
            try
            {
                DeleteLiftViewModel model = await liftService.GetLiftForDeleteAsync(id);
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
        public async Task<IActionResult> ConfirmDeleteLiftType(DeleteLiftTypeViewModel model)
        {
            try
            {
                await liftService.DeleteLiftTypeAsync(model);
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
