// ViewModels/Account/LoginViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace SwiftCart.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

      [Required(ErrorMessage = "Please select your account role.")]
         public string Role { get; set; } = string.Empty;


    }
}
