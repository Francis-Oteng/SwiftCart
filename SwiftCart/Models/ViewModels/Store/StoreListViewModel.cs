using System.Collections.Generic;

namespace SwiftCart.Models.ViewModels.Store
{
    public class StoreListViewModel
    {
        public IEnumerable<StoreListItemViewModel> Stores { get; set; }
            = new List<StoreListItemViewModel>();

        public string? SearchTerm { get; set; }

        public string? Location { get; set; }
    }
}