```csharp
using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int StoreId { get; set; }

        public Store Store { get; set; } = null!;

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        public ApplicationUser Customer { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(2000)]
        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
```
