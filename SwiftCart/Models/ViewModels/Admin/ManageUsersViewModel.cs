
// ViewModels/Admin/ManageUsersViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Admin
{
    public class ManageUsersViewModel
    {
        public IEnumerable<AdminUserViewModel> Users { get; set; }
            = new List<AdminUserViewModel>();

        public string? SearchTerm { get; set; }

        public UserRole? Role { get; set; }

        public bool? IsActive { get; set; }
    }

    public class AdminUserViewModel
    {
        public string UserId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
