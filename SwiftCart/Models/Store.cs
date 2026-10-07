using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; } = string.Empty;

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Url]
        public string? Website { get; set; }

        public string? LogoUrl { get; set; }

        // Store approval/status
        public StoreStatus Status { get; set; } = StoreStatus.Pending;

        // Whether the store is currently accepting orders
        public bool IsOpen { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ApprovedDate { get; set; }

        // Store owner
        [Required]
        public string OwnerId { get; set; } = string.Empty;

        public ApplicationUser Owner { get; set; } = null!;

        // Products
        public ICollection<Product> Products { get; set; }
            = new List<Product>();

        // Orders
        public ICollection<Order> Orders { get; set; }
            = new List<Order>();

        // Reviews
        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();
    }
}