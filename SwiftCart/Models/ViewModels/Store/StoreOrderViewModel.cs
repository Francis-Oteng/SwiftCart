// ViewModels/Store/StoreOrderViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Store
{
    public class StoreOrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        public IEnumerable<OrderItemViewModel> Items { get; set; }
            = new List<OrderItemViewModel>();

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
```
