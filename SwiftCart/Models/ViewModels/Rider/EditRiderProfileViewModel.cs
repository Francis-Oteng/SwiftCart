// ViewModels/Rider/EditRiderProfileViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SwiftCart.Models;

namespace SwiftCart.ViewModels.Rider
{
    public class EditRiderProfileViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        [StringLength(100)]
        public string VehicleNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string? VehicleDescription { get; set; }

        public string? ExistingProfilePhotoUrl { get; set; }

        public IFormFile? ProfilePhoto { get; set; }
    }
}

