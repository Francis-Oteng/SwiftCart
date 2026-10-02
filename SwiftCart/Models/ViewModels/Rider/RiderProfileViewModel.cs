// ViewModels/Rider/RiderProfileViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Rider
{
    public class RiderProfileViewModel
    {
        public string RiderName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? ProfilePhotoUrl { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VehicleNumber { get; set; } = string.Empty;

        public string? VehicleDescription { get; set; }

        public RiderApprovalStatus ApprovalStatus { get; set; }

        public bool IsAvailable { get; set; }
    }
}

