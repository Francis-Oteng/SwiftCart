// ViewModels/Product/ProductDetailsViewModel.cs

namespace SwiftCart.Models.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public decimal Price { get; set; }

        // Matches Product.AvailableStock
        public int AvailableStock { get; set; }

        public string? ImageUrl { get; set; }

        public ProductStoreViewModel Store { get; set; }
            = new ProductStoreViewModel();

        public ProductCategoryViewModel Category { get; set; }
            = new ProductCategoryViewModel();

        public double Rating { get; set; }

        public bool IsAvailable { get; set; }
    }

    public class ProductStoreViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }

    public class ProductCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
