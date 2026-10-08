using SwiftCart.Models;

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