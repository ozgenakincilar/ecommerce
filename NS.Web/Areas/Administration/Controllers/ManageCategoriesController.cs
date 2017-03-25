using AutoMapper;
using NS.Business.Categories;
using NS.Orm;
using NS.Web.Areas.Administration.Models.Categories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NS.Web.Areas.Administration.Controllers
{
    public class ManageCategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public ManageCategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(categoryViewModel);
                
                var category = Mapper.Map<Category>(categoryViewModel);

                _categoryRepository.Create(category);

                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return View(categoryViewModel);
            }
        }

        public ActionResult List()
        {
            var categories = _categoryRepository.List();

            var categoryViewModels = categories.Select(x => Mapper.Map<CategoryViewModel>(x)).ToList();

            return View(categoryViewModels);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("List");

                _categoryRepository.Delete(id.Value);

                return RedirectToAction("List");
            }
            catch (Exception exception)
            {
                return RedirectToAction("List");
            }
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("List");

            var category = _categoryRepository.Load(id.Value);

            var categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
                return View(categoryViewModel);
            
            var category = Mapper.Map<Category>(categoryViewModel);

            _categoryRepository.Update(category);

            return RedirectToAction("List");
        }
    }
}