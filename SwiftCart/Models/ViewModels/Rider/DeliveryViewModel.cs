// ViewModels/Rider/DeliveryViewModel.cs

using SwiftCart.Models;

namespace SwiftCart.ViewModels.Rider
{
    public class DeliveryViewModel
    {
        public int DeliveryId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string StoreName { get; set; } = string.Empty;

        public string PickupAddress { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string DeliveryAddress { get; set; } = string.Empty;

        public DeliveryStatus DeliveryStatus { get; set; }

        public double Distance { get; set; }

        public decimal DeliveryFee { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}