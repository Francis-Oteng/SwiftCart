using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Rider
    {
        public int RiderId { get; set; }

        // Identity user
        [Required]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;


        // Vehicle information
        [Required]
        [StringLength(100)]
        public string VehicleNumber { get; set; } = string.Empty;

        public VehicleType VehicleType { get; set; } = VehicleType.Motorcycle;

        [StringLength(200)]
        public string? VehicleDescription { get; set; }


        // Rider approval
        public RiderApprovalStatus ApprovalStatus { get; set; }
            = RiderApprovalStatus.Pending;


        public DateTime? ApprovedDate { get; set; }

        public DateTime? RejectedDate { get; set; }

        [StringLength(500)]
        public string? RejectionReason { get; set; }


        // Rider availability
        public bool IsAvailable { get; set; } = false;

        public bool IsOnline { get; set; } = false;


        // Rider profile
        [StringLength(500)]
        public string? ProfilePhotoUrl { get; set; }

        [Phone]
        [StringLength(30)]
        public string? PhoneNumber { get; set; }


        // Current location
        [Column(TypeName = "decimal(10,7)")]
        public decimal? CurrentLatitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal? CurrentLongitude { get; set; }

        public DateTime? LastLocationUpdate { get; set; }


        // Registration / account dates
        public DateTime CreatedDate { get; set; }
            = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }


        // Delivery relationship
        public ICollection<Delivery> Deliveries { get; set; }
            = new List<Delivery>();
    }
}