using SwiftCart.Models;
using System.Collections.Generic;

namespace SwiftCart.Models.ViewModels.Order
{
    public class OrderTrackingViewModel
    {
        public string OrderNumber { get; set; } = string.Empty;

        public OrderStatus Status { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;

        public int? DeliveryId { get; set; }

        public List<OrderTrackingStepViewModel> Steps { get; set; }
            = new List<OrderTrackingStepViewModel>();
    }
}

