using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int? RiderId { get; set; }

        public Rider? Rider { get; set; }

        public DeliveryStatus Status { get; set; }
            = DeliveryStatus.WaitingForRider;

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFee { get; set; }

        public DateTime? AssignedDate { get; set; }

        public DateTime? PickupDate { get; set; }

        public DateTime? StartDeliveryDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }

        public ICollection<DeliveryTracking> TrackingHistory { get; set; }
            = new List<DeliveryTracking>();
    }
}

