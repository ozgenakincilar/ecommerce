using NS.Business.Suppliers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NS.Business.Helpers.ListHelpers
{
    public class SupplierListHelper : ISupplierListHelper
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierListHelper(ISupplierRepository _supplierRepository)
        {
            this._supplierRepository = _supplierRepository;
        }

        public IEnumerable<SelectListItem> Get(string[] selectedValues)
        {
            var suppliers = _supplierRepository.List().Select(x => new SelectListItem()
            {
                Selected = selectedValues != null && selectedValues.Contains(x.SupplierID.ToString()),
                Text = x.CompanyName,
                Value = x.SupplierID.ToString()
            }).ToList();

            return suppliers;
        }
    }
}
