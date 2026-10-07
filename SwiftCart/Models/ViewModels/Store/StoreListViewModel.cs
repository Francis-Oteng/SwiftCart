// ViewModels/Store/StoreListViewModel.cs

namespace SwiftCart.Models.ViewModels.Store
{
    public class StoreListViewModel
    {
        public IEnumerable<StoreListItemViewModel> Stores { get; set; }
            = new List<StoreListItemViewModel>();

        public string? Search { get; set; }
        public string? Location { get; set; }
    }
}
namespace SwiftCart.Models.ViewModels.Store
{
    public class StoreListItemViewModel
    {
        public int StoreId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Location { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? LogoUrl { get; set; }

        public bool IsOpen { get; set; }

        public StoreStatus Status { get; set; }

        public int ProductCount { get; set; }
    }
}

public enum StoreStatusDisplay
    {
        Pending,
        Approved,
        Rejected,
        Suspended,
        Closed
    }
