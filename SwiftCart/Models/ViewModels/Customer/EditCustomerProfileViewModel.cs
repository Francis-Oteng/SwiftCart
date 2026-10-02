```csharp
// ViewModels/Customer/EditCustomerProfileViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SwiftCart.Models.ViewModels.Customer
{
    public class EditCustomerProfileViewModel
    {
        [Required]
        [StringLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? ExistingProfilePhotoUrl { get; set; }

        public IFormFile? ProfilePhoto { get; set; }
    }
}
```