// ViewModels/Home/HomeViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Account
{
    public class HomeViewModel
    {
        public string? SearchTerm { get; set; }

        public IEnumerable<Category> Categories { get; set; }
            = new List<Category>();

        public IEnumerable<StoreCardViewModel> NearbyStores { get; set; }
            = new List<StoreCardViewModel>();

        public IEnumerable<ProductCardViewModel> FeaturedProducts { get; set; }
            = new List<ProductCardViewModel>();

        public IEnumerable<ProductCardViewModel> PopularProducts { get; set; }
            = new List<ProductCardViewModel>();
    }

    public class StoreCardViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public bool IsOpen { get; set; }
        public double Rating { get; set; }
    }

    public class ProductCardViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? StoreName { get; set; }
        public string? CategoryName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
```
