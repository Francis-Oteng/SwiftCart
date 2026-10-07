using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class DeliveryTracking
    {
        public int DeliveryTrackingId { get; set; }


    public int DeliveryId { get; set; }

        public Delivery Delivery { get; set; } = null!;

        [Column(TypeName = "decimal(10,7)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal Longitude { get; set; }

        public DeliveryTrackingStatus Status { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }

        public DateTime RecordedDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }


}

