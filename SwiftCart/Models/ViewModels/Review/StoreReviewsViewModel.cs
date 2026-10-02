
// ViewModels/Review/StoreReviewsViewModel.cs

namespace SwiftCart.ViewModels.Review
{
    public class StoreReviewsViewModel
    {
        public int StoreId { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public double AverageRating { get; set; }

        public int TotalReviews { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
            = new List<ReviewViewModel>();
    }
}
