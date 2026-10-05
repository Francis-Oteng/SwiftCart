// ViewModels/Admin/ManageRidersViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Admin
{
    public class ManageRidersViewModel
    {
        public IEnumerable<AdminRiderViewModel> Riders { get; set; }
            = new List<AdminRiderViewModel>();

        public string? SearchTerm { get; set; }

        public RiderApprovalStatus? ApprovalStatus { get; set; }
    }

    public class AdminRiderViewModel
    {
        public int RiderId { get; set; }
        public string RiderName { get; set; } = string.Empty;
        public string Name => RiderName;
        public string VehicleNumber { get; set; } = string.Empty;
        public VehicleType VehicleType { get; set; }
        public RiderApprovalStatus ApprovalStatus { get; set; }
        public bool IsAvailable { get; set; }
        public bool CanApprove => ApprovalStatus == RiderApprovalStatus.Pending;
    }
}
