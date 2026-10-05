

// ViewModels/Admin/ManageStoresViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Admin
{
    public class ManageStoresViewModel
    {
        public IEnumerable<AdminStoreViewModel> Stores { get; set; }
            = new List<AdminStoreViewModel>();

        public string? SearchTerm { get; set; }

        public StoreStatus? ApprovalStatus { get; set; }
    }

    public class AdminStoreViewModel
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StoreName => Name;
        public string OwnerName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public StoreStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CanApprove => Status == StoreStatus.Pending;
        public bool CanReject => Status == StoreStatus.Pending;
        public bool CanSuspend => Status == StoreStatus.Approved;
    }
}
