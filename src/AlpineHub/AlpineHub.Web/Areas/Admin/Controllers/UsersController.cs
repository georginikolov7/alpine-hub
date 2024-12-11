using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AlpineHub.Core.Contracts;
using AlpineHub.Web.Controllers;

using static AlpineHub.Common.ApplicationConstants;
using static AlpineHub.Common.ErrorMessages;
using AlpineHub.Core.ViewModels.User;

namespace AlpineHub.Web.Areas.Admin.Controllers
{
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
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
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
                return BadRequest();
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult AssignRole(string id)
        {
            RoleFormModel model = new()
            {
                UserId = id
            };
            return PartialView("_AssignRoleModalContent", model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await userService.AssignRole(model);
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
        [HttpGet]
        public IActionResult RemoveRole(string id)
        {
            RoleFormModel model = new()
            {
                UserId = id
            };
            return PartialView("_RemoveRoleModalContent", model);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(RoleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await userService.RemoveRole(model);
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
