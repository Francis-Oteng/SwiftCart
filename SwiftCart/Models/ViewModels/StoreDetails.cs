// ViewModels/Store/StoreDetailsViewModel.cs

namespace SwiftCart.ViewModels.Store
{
    public class StoreDetailsViewModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string Name => StoreName;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Location => Address;

        public double Rating { get; set; }

        public bool IsOpen { get; set; }

        public IEnumerable<StoreProductViewModel> Products { get; set; }
            = new List<StoreProductViewModel>();

        public IEnumerable<CategoryOptionViewModel> Categories { get; set; }
            = new List<CategoryOptionViewModel>();
    }

    public class StoreProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CategoryOptionViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
