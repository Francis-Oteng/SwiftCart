using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftCart.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        [StringLength(100)]
        public string? TransactionReference { get; set; }

        [StringLength(100)]
        public string? ProviderReference { get; set; }

        [StringLength(50)]
        public string? MobileMoneyProvider { get; set; }

        [StringLength(30)]
        public string? MobileMoneyNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? PaidDate { get; set; }

        public DateTime? RefundedDate { get; set; }
    }
}

