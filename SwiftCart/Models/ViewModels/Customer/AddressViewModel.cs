// ViewModels/Customer/AddressViewModels.cs

using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models.ViewModels.Customer
{
    public class AddressListViewModel
    {
        public IEnumerable<AddressItemViewModel> Addresses { get; set; }
            = new List<AddressItemViewModel>();
    }

 
    
        public class AddressItemViewModel
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


    public class AddAddressViewModel
    {
        [Required]
        [StringLength(100)]
        public string Label { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string RecipientName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string AddressLine { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string? Region { get; set; }

        public string? DigitalAddress { get; set; }

        public bool IsDefault { get; set; }
    }

    public class EditAddressViewModel : AddAddressViewModel
    {
        public int AddressId { get; set; }
    }

