// ViewModels/Customer/CustomerProfileViewModel.cs

namespace SwiftCart.Models.ViewModels.Customer
{
    public class CustomerProfileViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        public int TotalOrders { get; set; }
        public int SavedAddresses { get; set; }

    }
}
