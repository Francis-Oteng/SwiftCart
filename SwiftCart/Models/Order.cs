```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Order
    {
        public int OrderId { get; set; }

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

        // Delivery address snapshot/reference
        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;

        [StringLength(300)]
        public string? DeliveryInstructions { get; set; }

        // Financial information
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ConfirmedDate { get; set; }

        public DateTime? PreparingDate { get; set; }

        public DateTime? ReadyForPickupDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public DateTime? CancelledDate { get; set; }

        [StringLength(1000)]
        public string? CancellationReason { get; set; }

        // Items
        public ICollection<OrderItem> Items { get; set; }
            = new List<OrderItem>();

        // Payment
        public Payment? Payment { get; set; }

        // Delivery
        public Delivery? Delivery { get; set; }

        // Review
        public Review? Review { get; set; }
    }
}
```
