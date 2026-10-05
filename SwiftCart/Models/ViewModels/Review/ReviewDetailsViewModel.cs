// ViewModels/Review/ReviewDetailsViewModel.cs
 namespace SwiftCart.ViewModels.Review
{
    public class ReviewDetailsViewModel 
{
    public ReviewViewModel Review { get; set; }
            = new ReviewViewModel();

    public int ReviewId => Review.ReviewId;

    public string StoreName => Review.StoreName;

    public string CustomerName => Review.CustomerName;

    public int Rating => Review.Rating;

    public string? Comment => Review.Comment;

    public DateTime CreatedDate => Review.CreatedDate;

    public bool CanEdit { get; set; }

  }

}