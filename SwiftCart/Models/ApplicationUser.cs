using Microsoft.AspNetCore.Identity;

namespace SwiftCart.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Customer;

        public string? ProfilePhotoUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginDate { get; set; }

        // Customer relationships
        public ICollection<Address> Addresses { get; set; }
            = new List<Address>();

        public Cart? Cart { get; set; }

        public ICollection<Order> Orders { get; set; }
            = new List<Order>();

        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();

        // Store owner relationship
        public ICollection<Store> Stores { get; set; }
            = new List<Store>();

        // Rider relationship
        public Rider? Rider { get; set; }

        // Notifications
        public ICollection<Notification> Notifications { get; set; }
            = new List<Notification>();
    }
}

