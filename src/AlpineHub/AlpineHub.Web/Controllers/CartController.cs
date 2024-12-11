using AlpineHub.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AlpineHub.Common.ErrorMessages;
namespace AlpineHub.Web.Controllers
{
    public class CartController(ILogger<CartController> _logger, ICartService cartService) : BaseController(_logger)
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await cartService.GetCart(GetUserId());
                return View(model);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToCart(string? passId, int quantity)
        {
            try
            {
                int cartCount = await cartService.AddToCart(passId, GetUserId(), quantity);

                return Ok(cartCount);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateItemQuantity(string? itemId, int quantity)
        {
            try
            {
                await cartService.UpdateItemQuantity(itemId, GetUserId(), quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCartCount()
        {
            try
            {
                int count = await cartService.GetCartCount(GetUserId());
                return Ok(count);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                return Ok(0);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(UnexpectedError);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveItem(string? itemId)
        {
            try
            {
                await cartService.DeleteItem(itemId, GetUserId());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                TempData["ErrorMessage"] = UnexpectedError;
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                await cartService.ClearCart(GetUserId());
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
