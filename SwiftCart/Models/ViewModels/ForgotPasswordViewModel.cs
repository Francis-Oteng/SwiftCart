// ViewModels/Account/ForgotPasswordViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace SwiftCart.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
