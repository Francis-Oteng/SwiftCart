// ViewModels/Admin/AdminDashboardViewModel.cs

namespace SwiftCart.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalCustomers { get; set; }
        public int TotalStores { get; set; }
        public int TotalRiders { get; set; }
        public int TotalOrders { get; set; }

        public int PendingStoreApprovals { get; set; }
        public int PendingRiderApprovals { get; set; }

        public int TodaysOrders { get; set; }

        public decimal TodayRevenue { get; set; }

        public IEnumerable<AdminRecentOrderViewModel> RecentOrders { get; set; }
            = new List<AdminRecentOrderViewModel>();
    }

    public class AdminRecentOrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string RiderName { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}






