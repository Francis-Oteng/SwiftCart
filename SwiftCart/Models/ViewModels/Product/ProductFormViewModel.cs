

// ViewModels/Product/ProductFormViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.Models.ViewModels.Product
{
    public class ProductFormViewModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableStock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryOptionViewModel> CategoryOptions { get; set; }
            = new List<CategoryOptionViewModel>();

        [Required]
        public int StoreId { get; set; }

        public IEnumerable<StoreOptionViewModel> StoreOptions { get; set; }
            = new List<StoreOptionViewModel>();

        public IFormFile? ImageFile { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

    public class CategoryOptionViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class StoreOptionViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
```
