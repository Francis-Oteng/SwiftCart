
// ViewModels/Order/OrderListViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Order
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderSummaryViewModel> Orders { get; set; }
            = new List<OrderSummaryViewModel>();

        public string? Filter { get; set; }

        public string? SearchTerm { get; set; }
    }
}