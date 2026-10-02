// ViewModels/Rider/AvailableDeliveriesViewModel.cs

namespace SwiftCart.ViewModels.Rider
{
    public class AvailableDeliveriesViewModel
    {
        public IEnumerable<DeliveryViewModel> Deliveries { get; set; }
            = new List<DeliveryViewModel>();

        public string? SearchTerm { get; set; }
    }
}
```