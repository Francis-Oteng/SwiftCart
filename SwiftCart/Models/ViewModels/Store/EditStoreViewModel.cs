// ViewModels/Store/CreateStoreViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.Models.ViewModels.Store
{
    public class CreateStoreViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string? Region { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public IFormFile? Logo { get; set; }
    }
}


