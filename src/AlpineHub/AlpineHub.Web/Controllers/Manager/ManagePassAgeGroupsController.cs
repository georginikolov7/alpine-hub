
namespace AlpineHub.Web.Controllers.Manager
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AlpineHub.Core.Contracts.Pass;
    using AlpineHub.Core.ViewModels.PassAgeGroup;

    using static AlpineHub.Data.Constants.CustomClaims;
    using static AlpineHub.Common.ErrorMessages;

    [Authorize(Policy = ManagerPolicyName)]
    public class ManagePassAgeGroupsController(ILogger<ManagePassAgeGroupsController> _logger, IManageablePassAgeService service) : BaseController(_logger)
    {
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAgeGroupsAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddAgeGroup()
        {
            AddAgeGroupFormModel model = new();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAgeGroup(AddAgeGroupFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                service.AddAgeGroupAsync(model);
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
        public async Task<IActionResult> EditAgeGroup(string? id)
        {
            try
            {
                EditAgeGroupFormModel model = await service.GetAgeGroupForEditAsync(id);
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
        public async Task<IActionResult> EditAgeGroup(EditAgeGroupFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.EditAgeGroup(model);
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
        public async Task<IActionResult> DeleteAgeGroup(string? id)
        {
            try
            {
                DeleteAgeGroupViewModel model = await service.GetAgeGroupForDeleteAsync(id);
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
        public async Task<IActionResult> ConfirmDeleteAgeGroup(DeleteAgeGroupViewModel model)
        {
            try
            {
                await service.DeleteAgeGroupAsync(model);
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
