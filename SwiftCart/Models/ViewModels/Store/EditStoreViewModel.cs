



// ViewModels/Store/CreateStoreViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.Models.ViewModels.Store
{
    public class CreateStoreViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string? Region { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public IFormFile? Logo { get; set; }
    }
}

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

```csharp
// ViewModels/Store/StoreOrderViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Store
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

```csharp
// ViewModels/Store/StoreOrdersViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Store
{
    public class StoreOrdersViewModel
    {
        public IEnumerable<StoreOrderRowViewModel> Orders { get; set; }
            = new List<StoreOrderRowViewModel>();

        public string? SearchTerm { get; set; }
        public OrderStatus? Status { get; set; }
    }

    public class StoreOrderRowViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
```

```csharp
// ViewModels/Store/MyStoreViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Store
{
    public class MyStoreViewModel
    {
        public StoreSummaryViewModel Store { get; set; }
            = new StoreSummaryViewModel();
    }

    public class StoreSummaryViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Location { get; set; } = string.Empty;
        public StoreStatus Status { get; set; }
        public bool IsOpen { get; set; }
        public string? LogoUrl { get; set; }
    }
}

