using NS.Business.Categories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NS.Business.Helpers.ListHelpers
{
    public class CategoryListHelper : ICategoryListHelper
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryListHelper(ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }

        public IEnumerable<SelectListItem> Get(string[] selectedValues)
        {
            var categories = _categoryRepository.List().Select(x => new SelectListItem()
            {
                Selected = selectedValues != null && selectedValues.Contains(x.CategoryID.ToString()),
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            return categories;
        }
    }
}
