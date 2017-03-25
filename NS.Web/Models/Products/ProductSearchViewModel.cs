using System.Collections.Generic;

namespace NS.Web.Models.Products
{
    public class ProductSearchViewModel
    {
        public ProductSearchViewModel()
        {
            ProductSearchCriteria = new ProductSearchCriteriaViewModel();
            Products = new List<ProductViewModel>();
        }

        public ProductSearchCriteriaViewModel ProductSearchCriteria { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public int? TotalItemCount { get; set; }
        public int? TotalPageCount { get; set; }
        public int? PageSize { get; set; }
        public int? CurrentPageIndex { get; set; }
    }
}