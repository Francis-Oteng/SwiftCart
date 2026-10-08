
using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string RecipientName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string AddressLine { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Region { get; set; }

        [StringLength(100)]
        public string? DigitalAddress { get; set; }

        public bool IsDefault { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;
    }
}

