// ViewModels/Checkout/CheckoutViewModel.cs

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Cart;

namespace SwiftCart.Models.ViewModels.Checkout
{
    public class CheckoutViewModel
    {
        public IEnumerable<CartItemViewModel> CartItems { get; set; }
            = new List<CartItemViewModel>();

        [Required]
        [Display(Name = "Delivery Address")]
        public int SelectedAddressId { get; set; }

        public int AddressId
        {
            get => SelectedAddressId;
            set => SelectedAddressId = value;
        }

        public IEnumerable<CheckoutAddressViewModel> Addresses { get; set; }
            = new List<CheckoutAddressViewModel>();

        public IEnumerable<SelectListItem> AddressOptions =>
            Addresses.Select(a => new SelectListItem
            {
                Value = a.AddressId.ToString(),
                Text = $"{a.Label} - {a.AddressLine}, {a.City}"
            });

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

        public string? DeliveryInstructions
        {
            get => Notes;
            set => Notes = value;
        }

        public IEnumerable<CartItemViewModel> Items
        {
            get => CartItems;
            set => CartItems = value;
        }

        public IEnumerable<SelectListItem> PaymentMethodOptions =>
            Enum.GetValues<PaymentMethod>().Select(method => new SelectListItem
            {
                Value = ((int)method).ToString(),
                Text = method.ToString()
            });
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

namespace SwiftCart.Models.ViewModels.Admin
{
    public class CheckoutViewModel : SwiftCart.Models.ViewModels.Checkout.CheckoutViewModel
    {
    }
}