// ViewModels/Cart/CartViewModel.cs

namespace SwiftCart.ViewModels.Cart
{
    public class CartViewModel
    {
        public int CartId { get; set; }

        public IEnumerable<CartItemViewModel> Items { get; set; }
            = new List<CartItemViewModel>();

        public decimal Subtotal { get; set; }

        public decimal DeliveryFee { get; set; }

        public decimal ServiceFee { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }
    }
}

