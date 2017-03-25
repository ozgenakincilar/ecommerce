using AutoMapper;
using NS.Business.Categories;
using NS.Web.Models.Categories;
using System.Linq;
using System.Web.Mvc;

namespace NS.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Navigation()
        {
            var categories = _categoryRepository
                                .List()
                                .Select(x => Mapper.Map<CategoryViewModel>(x))
                                .ToList();


            return PartialView(categories);
        }
    }
}