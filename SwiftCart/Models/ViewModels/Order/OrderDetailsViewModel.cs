// ViewModels/Order/OrderDetailsViewModel.cs

using SwiftCart.Models;
using SwiftCart.ViewModels.Cart;

namespace SwiftCart.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public OrderStoreViewModel Store { get; set; }
            = new OrderStoreViewModel();

        public OrderCustomerViewModel Customer { get; set; }
            = new OrderCustomerViewModel();

        public OrderRiderViewModel? Rider { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }
            = new List<OrderItemViewModel>();

        public decimal Subtotal { get; set; }

        public decimal DeliveryFee { get; set; }

        public decimal ServiceFee { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public OrderAddressViewModel DeliveryAddress { get; set; }
            = new OrderAddressViewModel();

        public string? DeliverySlot { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class OrderStoreViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }

    public class OrderCustomerViewModel
    {
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }

    public class OrderRiderViewModel
    {
        public int RiderId { get; set; }
        public string RiderName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
    }

    public class OrderAddressViewModel
    {
        public int AddressId { get; set; }
        public string RecipientName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AddressLine { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? DigitalAddress { get; set; }
    }

    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }
    }
}