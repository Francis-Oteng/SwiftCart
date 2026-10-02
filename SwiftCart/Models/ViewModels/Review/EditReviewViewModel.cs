
// ViewModels/Review/EditReviewViewModel.cs

using System.ComponentModel.DataAnnotations;

namespace SwiftCart.ViewModels.Review
{
    public class EditReviewViewModel
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(2000)]
        public string? Comment { get; set; }

        public string StoreName { get; set; } = string.Empty;
    }
}
