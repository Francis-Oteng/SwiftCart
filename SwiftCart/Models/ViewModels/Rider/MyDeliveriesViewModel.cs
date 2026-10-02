// ViewModels/Rider/MyDeliveriesViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Rider
{
    public class MyDeliveriesViewModel
    {
        public IEnumerable<DeliveryViewModel> Deliveries { get; set; }
            = new List<DeliveryViewModel>();

        public DeliveryStatus? Status { get; set; }

        public string? SearchTerm { get; set; }
    }
}

