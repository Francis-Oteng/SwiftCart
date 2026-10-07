namespace SwiftCart.Models.ViewModels.Account
{
    public class PrivacyViewModel
    {
        // Page information
        public string Title { get; set; } = "Privacy Policy";

        public string AppName { get; set; } = "SwiftCart";

        public string Introduction { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        // Privacy policy sections
        public List<PrivacySectionViewModel> Sections { get; set; } = new();

        // Contact information
        public string ContactEmail { get; set; } = string.Empty;

        public string ContactPhone { get; set; } = string.Empty;

        public string ContactAddress { get; set; } = string.Empty;

        // Consent information
        public string ConsentMessage { get; set; } = string.Empty;

        public string CookieMessage { get; set; } = string.Empty;
    }

    public class PrivacySectionViewModel
    {
        public string Heading { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public List<string> Points { get; set; } = new();
    }
}