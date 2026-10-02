// ViewModels/Review/ReviewViewModel.cs

namespace SwiftCart.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        public int OrderId { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}






