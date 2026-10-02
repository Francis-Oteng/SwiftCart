// ViewModels/Rider/DeliveryDetailsViewModel.cs

namespace SwiftCart.ViewModels.Rider
{
    public class DeliveryDetailsViewModel
    {
        public DeliveryViewModel Delivery { get; set; }
            = new DeliveryViewModel();

        public IEnumerable<DeliveryTrackingItemViewModel> TrackingHistory { get; set; }
            = new List<DeliveryTrackingItemViewModel>();
    }

    public class DeliveryTrackingItemViewModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Note { get; set; }

        public DateTime RecordedDate { get; set; }
    }
}
