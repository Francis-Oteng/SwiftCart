
namespace SwiftCart.Models.ViewModels.Order
{
    public class OrderTrackingStepViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}

