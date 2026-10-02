
// ViewModels/Product/ProductListViewModel.cs

namespace SwiftCart.ViewModels.Product
{
    public class ProductListViewModel
    {
        public string? Search { get; set; }

        public string? SearchTerm
        {
            get => Search;
            set => Search = value;
        }

        public int? CategoryId { get; set; }
        public int? StoreId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string? SortBy { get; set; }

        public IEnumerable<ProductListItemViewModel> Products { get; set; }
            = new List<ProductListItemViewModel>();

        public IEnumerable<CategoryOptionViewModel> CategoryOptions { get; set; }
            = new List<CategoryOptionViewModel>();
    }

    public class ProductListItemViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public string? StoreName { get; set; }

        public decimal Price { get; set; }
        public int AvailableStock { get; set; }

        public bool IsAvailable { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CategoryOptionViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
