using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; } = string.Empty;


        // Customer
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        public ApplicationUser Customer { get; set; } = null!;


        // Store
        public int StoreId { get; set; }

        public Store Store { get; set; } = null!;


        // Delivery address
        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;

        [StringLength(300)]
        public string? DeliveryInstructions { get; set; }


        // Order items
        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();


        // Financial information
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


        // Order status
        public OrderStatus Status { get; set; }
            = OrderStatus.Pending;

        public DateTime CreatedDate { get; set; }
            = DateTime.UtcNow;

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? PreparingDate { get; set; }

        public DateTime? ReadyForPickupDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        [StringLength(1000)]
        public string? CancellationReason { get; set; }


        // Payment
        public Payment? Payment { get; set; }


        // Delivery
        public Delivery? Delivery { get; set; }


        // Review
        public Review? Review { get; set; }
    }
}