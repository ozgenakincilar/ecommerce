using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace NS.Web.Models.Products
{
    public class ProductSearchCriteriaViewModel
    {
        public ProductSearchCriteriaViewModel()
        {
            Categories = new List<SelectListItem>();
            Suppliers = new List<SelectListItem>();
            SelectedCategories = new List<string>();
            SelectedSuppliers = new List<string>();
        }

        [DisplayName("Search")]
        public string SearchTerm { get; set; }

        [DisplayName("Categories")]
        public List<string> SelectedCategories { get; set; }

        [DisplayName("Suppliers")]
        public List<string> SelectedSuppliers { get; set; }

        [DisplayName("Is in stock ?")]
        public bool IsInStock { get; set; }

        [DisplayName("Is continued ?")]
        public bool IsContinued { get; set; }

        [DisplayName("Min unit price")]
        public decimal? MinUnitPrice { get; set; }

        [DisplayName("Max unit price")]
        public decimal? MaxUnitPrice { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Suppliers { get; set; }
    }
}