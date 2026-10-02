using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models
{
    public class Rider
    {
        public int RiderId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string VehicleNumber { get; set; } = string.Empty;

        public VehicleType VehicleType { get; set; }

        [StringLength(100)]
        public string? VehicleDescription { get; set; }

        public RiderApprovalStatus ApprovalStatus { get; set; }
            = RiderApprovalStatus.Pending;

        public string? ProfilePhotoUrl { get; set; }

        public bool IsAvailable { get; set; }

        public decimal CurrentLatitude { get; set; }

        public decimal CurrentLongitude { get; set; }

        public DateTime? LastLocationUpdate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ApprovedDate { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
            = new List<Delivery>();
    }
}

