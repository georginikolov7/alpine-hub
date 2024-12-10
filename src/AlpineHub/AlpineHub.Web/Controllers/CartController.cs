using AlpineHub.Core.Contracts;
using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
                logger.LogError(ex, "Error getting cart");
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

                return Ok("Pass added successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding to cart");
                return BadRequest();
            }
        }
    }
}
