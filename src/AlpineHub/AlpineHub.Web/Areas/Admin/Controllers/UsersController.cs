namespace AlpineHub.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AlpineHub.Core.Contracts;
    using AlpineHub.Web.Controllers;

    using static AlpineHub.Common.ApplicationConstants;
    using AlpineHub.Core.ViewModels.User;

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class UsersController(IUserService userService, ILogger<UsersController> _logger) : BaseController(_logger)
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await userService.GetAllUsersAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var model = await userService.DeleteUser(id);
                return PartialView("_DeleteConfirmationModal", model);
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteUser(DeleteUserViewModel model)
        {
            try
            {
                await userService.ConfirmDeleteUser(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = "Cannot delete user with admin role";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
