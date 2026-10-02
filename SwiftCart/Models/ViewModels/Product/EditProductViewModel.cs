// ViewModels/Product/EditProductViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.Models.ViewModels.Product
{
    public class EditProductViewModel
    {
        public int ProductId { get; set; }

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

        public string? ExistingImageUrl { get; set; }

        public IFormFile? NewImage { get; set; }

        public bool IsAvailable { get; set; }

        public IEnumerable<CategoryOptionViewModel> CategoryOptions { get; set; }
            = new List<CategoryOptionViewModel>();
    }
}