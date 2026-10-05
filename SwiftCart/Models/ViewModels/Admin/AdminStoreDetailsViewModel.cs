using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Admin
{
    public class AdminStoreDetailsViewModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public StoreStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool CanApprove => Status == StoreStatus.Pending;
        public bool CanReject => Status == StoreStatus.Pending;
    }
}
