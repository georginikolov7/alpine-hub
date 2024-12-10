using AlpineHub.Core.ViewModels.Cart;

namespace AlpineHub.Core.Contracts
{
    public interface ICartService
    {
        /// <summary>
        /// Finds by id and adds to cart
        /// </summary>
        /// <param name="passId"></param>
        /// <param name="userId"></param>
        /// <param name="quantity"></param>
        /// <returns>Number of items in cart</returns>
        Task<int> AddToCart(string? passId, string? userId, int quantity);

        Task<CartViewModel?> GetCart(string? userId);

    }
}
