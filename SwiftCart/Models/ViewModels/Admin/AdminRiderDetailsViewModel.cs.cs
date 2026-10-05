using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Admin
{
    public class AdminRiderDetailsViewModel
    {
        public int RiderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public string VehicleNumber { get; set; } = string.Empty;
        public RiderApprovalStatus ApprovalStatus { get; set; }
        public bool IsAvailable { get; set; }
        public bool CanApprove => ApprovalStatus == RiderApprovalStatus.Pending;
        public string AvailabilityStatus => IsAvailable ? "Available" : "Unavailable";
    }
}