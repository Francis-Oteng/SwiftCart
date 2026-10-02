// ViewModels/Order/OrderTrackingViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Order
{
    public class OrderTrackingViewModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public OrderStatus Status { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;

        public int? DeliveryId { get; set; }

        public IEnumerable<OrderTrackingStepViewModel> Steps { get; set; }
            = new List<OrderTrackingStepViewModel>();
    }

    public class OrderTrackingStepViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}

