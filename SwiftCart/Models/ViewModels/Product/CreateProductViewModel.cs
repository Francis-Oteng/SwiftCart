// ViewModels/Product/CreateProductViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Required]
        public int StoreId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableStock { get; set; }

        public IFormFile? Image { get; set; }

        public bool IsAvailable { get; set; } = true;

        public IEnumerable<CategoryOptionViewModel> CategoryOptions { get; set; }
            = new List<CategoryOptionViewModel>();

        public IEnumerable<StoreOptionViewModel> StoreOptions { get; set; }
            = new List<StoreOptionViewModel>();
    }

    public class StoreOptionViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
