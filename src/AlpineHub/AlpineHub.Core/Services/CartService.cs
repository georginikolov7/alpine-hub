using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Cart;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static AlpineHub.Common.ErrorMessages;
namespace AlpineHub.Core.Services
{
    public class CartService(IRepo repo, UserManager<ApplicationUser> userManager) : BaseService(repo), ICartService
    {
        public async Task<int> AddToCart(string? passId, string? userId, int quantity)
        {
            //Validate ids:
            if (!IsGuidValid(passId, out Guid passGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Pass", passId));
            }
            if (!IsGuidValid(userId, out Guid userGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "User", userId));
            }

            //Ensure user exists:
            ApplicationUser? user = await userManager.FindByIdAsync(userId!) ?? throw new ArgumentException(string.Format(UserNotFound, userId));

            //Get the cart:
            UserCart? cart = await repo.GetAll<UserCart>()
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userGuid);

            if (cart is null)
            {
                //Create a new cart:
                cart = new UserCart()
                {
                    UserId = userGuid,
                    CartItems = new List<CartItem>()
                };
                await repo.AddAsync(cart);
            }

            //Get the pass:
            Pass? pass = await repo.GetAll<Pass>()
                .FirstOrDefaultAsync(p => p.Id == passGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, passId));

            //Check if the pass is already in the cart:
            CartItem? cartItem = cart.CartItems
                .FirstOrDefault(ci => ci.PassId == passGuid);
            if (cartItem is not null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItem = new CartItem()
                {
                    CartId = cart.Id,
                    Pass = pass,
                    Quantity = quantity
                };
                await repo.AddAsync(cartItem);
            }
            await repo.SaveChangesAsync();

            return cart.CartItems.Count;
        }

        public async Task<CartViewModel?> GetCart(string? userId)
        {
            if (!IsGuidValid(userId, out Guid userGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "User", userId));
            }
            UserCart? cart = await repo.GetAllReadonly<UserCart>()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Pass)
                .FirstOrDefaultAsync(c => c.UserId == userGuid);

            if (cart is null)
            {
                return null;
            }
            IEnumerable<CartItemViewModel> items = cart.CartItems
                .Select(ci => new CartItemViewModel()
                {
                    Id = ci.Id.ToString(),
                    Name = ci.Pass.Name,
                    Price = ci.Pass.Price,
                    Quantity = ci.Quantity,

                });


            return new CartViewModel()
            {
                CartItems = items,
                CartTotalPrice = cart.TotalCartPrice
            };
        }
    }
}