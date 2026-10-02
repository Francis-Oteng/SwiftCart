// ViewModels/Admin/AdminOrdersViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Admin
{
    public class AdminOrdersViewModel
    {
        public IEnumerable<AdminOrderViewModel> Orders { get; set; }
            = new List<AdminOrderViewModel>();

        public string? SearchTerm { get; set; }

        public OrderStatus? Status { get; set; }

        public PaymentStatus? PaymentStatus { get; set; }
    }

    public class AdminOrderViewModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string StoreName { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

