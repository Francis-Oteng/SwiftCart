
// ViewModels/Review/MyReviewsViewModel.cs

namespace SwiftCart.ViewModels.Review
{
    public class MyReviewsViewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
            = new List<ReviewViewModel>();
    }
}

