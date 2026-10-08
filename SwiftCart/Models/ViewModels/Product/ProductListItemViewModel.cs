using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Product
{
    public class ProductListItemViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int AvailableStock { get; set; }

        public bool IsAvailable { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ProductStatus Status { get; set; }
    }
}

