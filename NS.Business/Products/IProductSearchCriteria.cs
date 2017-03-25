using NS.Infrastructure.Paging;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NS.Business.Products
{
    public interface IProductSearchCriteria
    {
        int? Id { get; set; }
        string SearchTerm { get; set; }
        List<string> SelectedCategories { get; set; }
        List<string> SelectedSuppliers { get; set; }
        bool IsInStock { get; set; }
        bool IsContinued { get; set; }
        decimal? MinUnitPrice { get; set; }
        decimal? MaxUnitPrice { get; set; }
        IEnumerable<SelectListItem> Categories { get; set; }
        IEnumerable<SelectListItem> Suppliers { get; set; }
        PagedBase PagedBase { get; set; }
    }
}
