```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int AvailableStock { get; set; }

        public string? ImageUrl { get; set; }

        public ProductStatus Status { get; set; } = ProductStatus.Active;

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        // Store
        public int StoreId { get; set; }

        public Store Store { get; set; } = null!;

        // Category
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        // Order items
        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();

        // Cart items
        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();
    }
}
```
