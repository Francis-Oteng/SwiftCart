using SwiftCart.Models;

namespace SwiftCart.Models.ViewModels.Admin
{
    public class AdminUserDetailsViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status => IsActive ? "Active" : "Inactive";
    }
}
