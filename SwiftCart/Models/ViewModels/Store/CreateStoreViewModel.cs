
// ViewModels/Store/EditStoreViewModel.cs

using Microsoft.AspNetCore.Http;
using SwiftCart.Models;
using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models.ViewModels.Store
{
    public class EditStoreViewModel
    {
        public int StoreId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? ExistingLogoUrl { get; set; }

        public IFormFile? Logo { get; set; }

        public bool IsOpen { get; set; }
    }
}




  







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
```
