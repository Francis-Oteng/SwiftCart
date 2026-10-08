// ViewModels/Product/ProductListViewModel.cs

namespace SwiftCart.Models.ViewModels.Product
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ProductListViewModel
    {
        public string? Search { get; set; }

        public string? SearchTerm
        {
            get => Search;
            set => Search = value;
        }

        public int? CategoryId { get; set; }
        public int? StoreId { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string? SortBy { get; set; }

        public IEnumerable<ProductListItemViewModel> Products { get; set; }
            = new List<ProductListItemViewModel>();

        public IEnumerable<SelectListItem> CategoryOptions { get; set; }
            = new List<SelectListItem>();
    }
}

   