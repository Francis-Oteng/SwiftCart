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
