using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Customer;
using SwiftCart.Models.ViewModels.Order;
using SwiftCart.ViewModels.Admin;
using SwiftCart.ViewModels.Review;
using SwiftCart.ViewModels.Rider;

namespace SwiftCart.Models.ViewModels.Admin
{
    public class OrdersViewModel : AdminOrdersViewModel { }
    public class RidersViewModel : ManageRidersViewModel { }
    public class StoresViewModel : ManageStoresViewModel { }
    public class UsersViewModel : ManageUsersViewModel { }
    public class RiderDetailsViewModel : AdminRiderDetailsViewModel { }
    public class StoreDetailsViewModel : AdminStoreDetailsViewModel { }
    public class UserDetailsViewModel : AdminUserDetailsViewModel { }

    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int ProductCount { get; set; }
    }

    public class CategoriesViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }

    public class ReportsViewModel
    {
        public decimal DailyRevenue { get; set; }
        public int WeeklyOrders { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public double DeliveryPerformance { get; set; }
        public IEnumerable<ReportStoreItemViewModel> TopStores { get; set; } = new List<ReportStoreItemViewModel>();
        public IEnumerable<ReportProductItemViewModel> TopProducts { get; set; } = new List<ReportProductItemViewModel>();
    }

    public class ReportStoreItemViewModel
    {
        public string StoreName { get; set; } = string.Empty;
        public int OrderCount { get; set; }
    }

    public class ReportProductItemViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
    }

    public class SettingsViewModel
    {
        public string PlatformName { get; set; } = string.Empty;
        public string SupportEmail { get; set; } = string.Empty;
        public string? SupportPhone { get; set; }
        public bool AllowNewStoreRegistrations { get; set; } = true;
    }
}

namespace SwiftCart.Models.ViewModels.Customer
{
    public class AddressFormViewModel : EditAddressViewModel { }
    public class AddressesViewModel : AddressListViewModel { }
    public class DashboardViewModel : CustomerDashboardViewModel { }
    public class EditProfileViewModel : EditCustomerProfileViewModel { }
}

namespace SwiftCart.Models.ViewModels
{
    public class CustomerProfileViewModel : SwiftCart.Models.ViewModels.Customer.CustomerProfileViewModel { }
    public class OrderListViewModel : SwiftCart.Models.ViewModels.Order.OrderListViewModel { }
    public class OrderDetailsViewModel : SwiftCart.Models.ViewModels.Order.OrderDetailsViewModel { }
    public class OrderTrackingViewModel : SwiftCart.Models.ViewModels.Order.OrderTrackingViewModel { }
    public class ProductFormViewModel : SwiftCart.Models.ViewModels.Product.ProductFormViewModel { }
    public class ProductListViewModel : SwiftCart.Models.ViewModels.Product.ProductListViewModel { }
    public class ProductDetailsViewModel : SwiftCart.Models.ViewModels.Product.ProductDetailsViewModel { }
    public class CreateReviewViewModel : SwiftCart.ViewModels.Review.CreateReviewViewModel
    {
        public IEnumerable<SelectListItem> RatingOptions =>
            Enumerable.Range(1, 5).Select(value => new SelectListItem(value.ToString(), value.ToString()));
    }

    public class EditReviewViewModel : SwiftCart.ViewModels.Review.EditReviewViewModel
    {
        public IEnumerable<SelectListItem> RatingOptions =>
            Enumerable.Range(1, 5).Select(value => new SelectListItem(value.ToString(), value.ToString()));
    }

    public class MyReviewsViewModel : SwiftCart.ViewModels.Review.MyReviewsViewModel { }
    public class ReviewDetailsViewModel : SwiftCart.ViewModels.Review.ReviewDetailsViewModel { }
    public class StoreReviewsViewModel : SwiftCart.ViewModels.Review.StoreReviewsViewModel { }

   

    public class NotificationItemViewModel
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class NotificationDetailsViewModel
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class RiderDashboardViewModel : SwiftCart.ViewModels.Rider.RiderDashboardViewModel { }
    public class RiderProfileViewModel : SwiftCart.ViewModels.Rider.RiderProfileViewModel { }
    public class EditRiderProfileViewModel : SwiftCart.ViewModels.Rider.EditRiderProfileViewModel { }
    public class MyDeliveriesViewModel : SwiftCart.ViewModels.Rider.MyDeliveriesViewModel { }
    public class AvailableDeliveriesViewModel : SwiftCart.ViewModels.Rider.AvailableDeliveriesViewModel { }

    public class RiderDeliveryDetailsViewModel
    {
        public int DeliveryId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool CanPickUp { get; set; }
        public bool CanStartDelivery { get; set; }
        public bool CanComplete { get; set; }
    }

    public class RiderEarningsViewModel
    {
        public decimal TotalEarnings { get; set; }
        public int CompletedDeliveries { get; set; }
        public decimal AverageEarnings { get; set; }
        public IEnumerable<RiderEarningItemViewModel> EarningsHistory { get; set; } = new List<RiderEarningItemViewModel>();
    }

    public class RiderEarningItemViewModel
    {
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime? CompletedAt { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Earnings { get; set; }
    }
}

namespace SwiftCart.Models.ViewModels.Home
{
    public class AboutViewModel { }
    public class HelpViewModel { }
    public class IndexViewModel { }
    public class PrivacyViewModel { }
}

namespace SwiftCart.Models.ViewModels.Checkout.Confirmation
{
    public class OrderConfirmationViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
    }
}

namespace SwiftCart.Models.ViewModels.Delivery
{
    public class InTransitViewModel
    {
        public int DeliveryId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
    }

    public class PickupViewModel
    {
        public int DeliveryId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
    }

    public class DeliveryTrackingStepViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime? Timestamp { get; set; }
    }

    public class TrackingViewModel
    {
        public string OrderNumber { get; set; } = string.Empty;
        public IEnumerable<DeliveryTrackingStepViewModel> TrackingSteps { get; set; } = new List<DeliveryTrackingStepViewModel>();
    }

    public class DeliveryRiderViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
    }

    public class DetailsViewModel
    {
        public int DeliveryId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal DeliveryFee { get; set; }
        public DeliveryRiderViewModel? Rider { get; set; }
        public DateTime? AssignedAt { get; set; }
        public DateTime? PickedUpAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }

    public class CompletedDeliveryViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime? DeliveredAt { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool CanReview { get; set; }
    }
}

namespace SwiftCart.ViewModels
{
    public class AdminDashboardViewModel : SwiftCart.ViewModels.Admin.AdminDashboardViewModel { }
    public class CartViewModel : SwiftCart.Models.ViewModels.Cart.CartViewModel { }
    public class StoreDetailsViewModel : SwiftCart.ViewModels.Store.StoreDetailsViewModel { }
    public class MyStoreViewModel : SwiftCart.Models.ViewModels.Store.MyStoreViewModel { }

    public class StoreFormViewModel : SwiftCart.Models.ViewModels.Store.CreateStoreViewModel
    {
        public int StoreId { get; set; }

        public string Location
        {
            get => Address;
            set => Address = value;
        }

        public IFormFile? LogoFile
        {
            get => Logo;
            set => Logo = value;
        }
    }

    public class StoreListViewModel : SwiftCart.Models.ViewModels.Store.StoreListViewModel
    {
        public string? Search
        {
            get => SearchTerm;
            set => SearchTerm = value;
        }
    }

    public class StoreOrderViewModel
    {
        public IEnumerable<StoreOrderListItemViewModel> Orders { get; set; } = new List<StoreOrderListItemViewModel>();
    }

    public class StoreOrderListItemViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class AdminOrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string RiderName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<AdminOrderItemViewModel> Items { get; set; } = new List<AdminOrderItemViewModel>();
    }

    public class AdminOrderItemViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}

namespace SwiftCart.ViewModels.Cart
{
    public sealed class NamespaceMarker { }
}
