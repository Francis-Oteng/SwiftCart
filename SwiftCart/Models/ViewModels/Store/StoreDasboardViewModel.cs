```csharp
// ViewModels/Store/StoreDashboardViewModel.cs

namespace SwiftCart.Models.ViewModels.Store
{
    public class StoreDashboardViewModel
    {
        public string StoreName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }

        public bool IsApproved { get; set; }
        public bool IsOpen { get; set; }

        public int Today'sOrders { get; set; }
        public int PendingOrders { get; set; }
        public int PreparingOrders { get; set; }
        public int CompletedOrders { get; set; }

        public decimal Today'sRevenue { get; set; }

        public IEnumerable<StoreOrderViewModel> RecentOrders { get; set; }
            = new List<StoreOrderViewModel>();

        public IEnumerable<LowStockProductViewModel> LowStockProducts { get; set; }
            = new List<LowStockProductViewModel>();
    }

    public class LowStockProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int AvailableStock { get; set; }
    }
}
```