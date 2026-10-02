// ViewModels/Checkout/CheckoutViewModel.cs

using System.ComponentModel.DataAnnotations;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Cart;

namespace SwiftCart.Models.ViewModels.Admin
{
    public class CheckoutViewModel
    {
        public IEnumerable<CartItemViewModel> CartItems { get; set; }
            = new List<CartItemViewModel>();

        [Required]
        [Display(Name = "Delivery Address")]
        public int SelectedAddressId { get; set; }

        public IEnumerable<CheckoutAddressViewModel> Addresses { get; set; }
            = new List<CheckoutAddressViewModel>();

        public DateTime? DeliveryDate { get; set; }

        public string? DeliverySlot { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        [StringLength(300)]
        public string? Notes { get; set; }
    }

    public class CheckoutAddressViewModel
    {
        public int AddressId { get; set; }

        public string Label { get; set; } = string.Empty;

        public string RecipientName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string AddressLine { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? Region { get; set; }

        public string? DigitalAddress { get; set; }

        public bool IsDefault { get; set; }
    }
}