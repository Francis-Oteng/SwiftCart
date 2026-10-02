// ViewModels/Rider/RiderLocationViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace SwiftCart.ViewModels.Rider
{
    public class RiderLocationViewModel
    {
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }
    }
}