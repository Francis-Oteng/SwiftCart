// ViewModels/Rider/RiderDashboardViewModel.cs

namespace SwiftCart.ViewModels.Rider
{
    public class RiderDashboardViewModel
    {
        public string RiderName { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        public int TodayDeliveries { get; set; }
        public int CompletedDeliveries { get; set; }
        public int PendingDeliveries { get; set; }

        public decimal TodayEarnings { get; set; }

        public IEnumerable<DeliveryViewModel> AvailableDeliveries { get; set; }
            = new List<DeliveryViewModel>();

        public DeliveryViewModel? CurrentDelivery { get; set; }
    }
}








