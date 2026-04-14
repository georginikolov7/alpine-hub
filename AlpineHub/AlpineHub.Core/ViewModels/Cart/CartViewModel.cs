namespace AlpineHub.Core.ViewModels.Cart
{
    public class CartViewModel
    {
        public decimal CartTotalPrice { get; set; }
        public IEnumerable<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
    }
}
