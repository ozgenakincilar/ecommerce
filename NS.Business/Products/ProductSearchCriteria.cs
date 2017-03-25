using NS.Infrastructure.Paging;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NS.Business.Products
{
    public class ProductSearchCriteria : IProductSearchCriteria
    {
        public int? Id { get; set; }
        public string SearchTerm { get; set; }
        public List<string> SelectedCategories { get; set; }
        public List<string> SelectedSuppliers { get; set; }
        public bool IsInStock { get; set; }
        public bool IsContinued { get; set; }
        public decimal? MinUnitPrice { get; set; }
        public decimal? MaxUnitPrice { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public PagedBase PagedBase { get; set; }
    }
}
