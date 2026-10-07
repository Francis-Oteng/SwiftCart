namespace SwiftCart.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();
    }
}