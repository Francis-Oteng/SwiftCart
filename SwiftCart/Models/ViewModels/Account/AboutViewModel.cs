namespace SwiftCart.Models.ViewModels.Account
{
    public class AboutViewModel
    {
        // Basic information
        public string AppName { get; set; } = "SwiftCart";

        public string Tagline { get; set; } =
            "Fast, fresh, and convenient grocery delivery.";

        public string Description { get; set; } = string.Empty;

        // Mission and vision
        public string Mission { get; set; } = string.Empty;

        public string Vision { get; set; } = string.Empty;

        // What SwiftCart offers
        public List<string> Services { get; set; } = new();

        // Key statistics
        public int TotalStores { get; set; }

        public int TotalProducts { get; set; }

        public int TotalCustomers { get; set; }

        public int TotalOrders { get; set; }

        // Contact information
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        // Social media / website
        public string? WebsiteUrl { get; set; }

        public string? FacebookUrl { get; set; }

        public string? InstagramUrl { get; set; }

        public string? TwitterUrl { get; set; }

        // Company branding
        public string? LogoUrl { get; set; }

        public string? HeroImageUrl { get; set; }

        // Features displayed on the About page
        public List<AboutFeatureViewModel> Features { get; set; } = new();

        // Team members
        public List<AboutTeamMemberViewModel> TeamMembers { get; set; } = new();
    }

    public class AboutFeatureViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Icon { get; set; }
    }

    public class AboutTeamMemberViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string? PhotoUrl { get; set; }

        public string? Bio { get; set; }
    }
}