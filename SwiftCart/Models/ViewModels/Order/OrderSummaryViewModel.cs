// ViewModels/Order/OrderSummaryViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Order
{
    public class OrderSummaryViewModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string StoreName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
