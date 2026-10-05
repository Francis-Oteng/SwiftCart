// ViewModels/Product/ProductFormViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SwiftCart.Models.ViewModels.Product
{
    public class ProductFormViewModel
    {
        public int ProductId { get; set; }

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

        public IEnumerable<SelectListItem> CategoryOptions { get; set; }
            = new List<SelectListItem>();

        [Required]
        public int StoreId { get; set; }

        public IEnumerable<SelectListItem> StoreOptions { get; set; }
            = new List<SelectListItem>();

        public IFormFile? ImageFile { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

}
