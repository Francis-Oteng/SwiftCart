// ViewModels/Customer/CustomerDashboardViewModel.cs

namespace SwiftCart.Models.ViewModels.Customer
{
    public class CustomerDashboardViewModel
    {
        public string CustomerName { get; set; } = string.Empty;

        public string? ProfileImageUrl { get; set; }

        public int TotalOrders { get; set; }
        public int ActiveOrders { get; set; }
        public int CompletedOrders { get; set; }

        public IEnumerable<CustomerOrderSummaryViewModel> RecentOrders { get; set; }
            = new List<CustomerOrderSummaryViewModel>();

        public IEnumerable<FavoriteStoreViewModel> FavoriteStores { get; set; }
            = new List<FavoriteStoreViewModel>();

        public int UnreadNotifications { get; set; }
    }

    public class CustomerOrderSummaryViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }

    public class FavoriteStoreViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
    }
}




