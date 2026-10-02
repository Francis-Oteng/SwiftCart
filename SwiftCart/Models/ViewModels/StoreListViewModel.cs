// ViewModels/Store/StoreListViewModel.cs

namespace SwiftCart.ViewModels.Store
{
    public class StoreListViewModel
    {
        public string? SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public string? Location { get; set; }

        public IEnumerable<StoreListItemViewModel> Stores { get; set; }
            = new List<StoreListItemViewModel>();
    }

    public class StoreListItemViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public StoreStatusDisplay Status { get; set; }
        public double Rating { get; set; }
    }

    public enum StoreStatusDisplay
    {
        Pending,
        Approved,
        Rejected,
        Suspended,
        Closed
    }
}