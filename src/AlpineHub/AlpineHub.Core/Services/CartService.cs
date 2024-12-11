namespace AlpineHub.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.ViewModels.Cart;
    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;

    using static AlpineHub.Common.ErrorMessages;
    public class CartService(IRepo repo, UserManager<ApplicationUser> userManager) : BaseService(repo), ICartService
    {
        public async Task<int> AddToCart(string? passId, string? userId, int quantity)
        {
            //Validate ids:
            if (!IsGuidValid(passId, out Guid passGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Pass", passId));
            }

            //Get user:
            ApplicationUser user = await GetUser(userId);

            //Get the cart:
            UserCart? cart = await GetUserCat(user);

            if (cart is null)
            {
                //Create a new cart:
                cart = new UserCart()
                {
                    UserId = user.Id,
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
                    PassId = pass.Id,
                    Pass = pass,
                    Quantity = quantity,
                    TotalPrice = pass.Price * quantity
                };
                await repo.AddAsync(cartItem);
            }
            await repo.SaveChangesAsync();

            return cart.CartItems.Count;
        }

        public async Task ClearCart(string? userId)
        {
            ApplicationUser user = await GetUser(userId);
            UserCart? cart = await GetUserCat(user);
            if (cart is null)
            {
                return;
            }
            repo.Delete(cart);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteItem(string? itemId, string? userId)
        {
            ApplicationUser user = await GetUser(userId);
            UserCart? cart = await GetUserCat(user);
            if (cart is null)
            {
                throw new InvalidOperationException(string.Format(CartNotFound, userId));
            }

            if (!IsGuidValid(itemId, out Guid itemGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Item", itemId));
            }

            CartItem item = await repo.GetByIdAsync<CartItem>(itemGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, itemId));

            repo.Delete(item);
            await repo.SaveChangesAsync();
        }

        public async Task<CartViewModel?> GetCart(string? userId)
        {
            ApplicationUser user = await GetUser(userId);


            UserCart? cart = await repo.GetAllReadonly<UserCart>()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Pass)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

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
                    TotalPrice = ci.TotalPrice

                });


            return new CartViewModel()
            {
                CartItems = items,
                CartTotalPrice = cart.TotalCartPrice
            };
        }

        public async Task<int> GetCartCount(string? userId)
        {
            if(userId is null)
            {
                return 0;
            }
            ApplicationUser user = await GetUser(userId);
            UserCart? cart = await GetUserCat(user);
            if (cart is null)
            {
                return 0;
            }
            return cart.CartItems.Count;

        }

        public async Task UpdateItemQuantity(string? itemId, string? userId, int quantity)
        {
            ApplicationUser user = await GetUser(userId);
            UserCart? cart = await GetUserCat(user);
            if (cart is null)
            {
                //Unexpected:
                throw new InvalidOperationException(string.Format(CartNotFound, userId));
            }

            if (!IsGuidValid(itemId, out Guid itemGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Item", itemId));
            }
            CartItem item = await repo
                .GetAll<CartItem>()
                .Include(ci => ci.Pass)
                .FirstOrDefaultAsync(ci => ci.Id == itemGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, itemId));

            item.Quantity = quantity;
            item.TotalPrice = quantity * item.Pass.Price;
            await repo.SaveChangesAsync();
        }

        private async Task<ApplicationUser> GetUser(string? userId)
        {
            if (!IsGuidValid(userId, out Guid userGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "User", userId));
            }

            //Ensure user exists:
            ApplicationUser? user = await userManager.FindByIdAsync(userId!) ?? throw new ArgumentException(string.Format(UserNotFound, userId));

            return user;
        }
        private async Task<UserCart?> GetUserCat(ApplicationUser user)
        {
            UserCart? cart = await repo.GetAll<UserCart>()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Pass)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);
            return cart;
        }
    }
}