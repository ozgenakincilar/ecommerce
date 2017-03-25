using NS.Business.Categories;
using NS.Business.Products;
using NS.Business.Suppliers;
using NS.Infrastructure.Paging;
using NS.Web.Areas.Administration.Models.Dashboard;
using System.Web.Mvc;

namespace NS.Web.Areas.Administration.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public DashboardController(ICategoryRepository categoryRepository, ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesCount()
        {
            var categoriesCountViewModel = new CategoriesCountViewModel();

            categoriesCountViewModel.CategoriesCount = _categoryRepository.List().Count;

            return PartialView(categoriesCountViewModel);
        }

        public ActionResult ProductsCount()
        {
            var productsCountViewModel = new ProductsCountViewModel();

            var productSearchCriteria = new ProductSearchCriteria();
            productSearchCriteria.PagedBase = new PagedBase();
            productSearchCriteria.PagedBase.PageSize = int.MaxValue;
            productSearchCriteria.PagedBase.PageIndex = int.MaxValue;

            productsCountViewModel.ProductsCount = _productRepository.Search(productSearchCriteria).TotalItemCount;

            return PartialView(productsCountViewModel);
        }

        public ActionResult SuppliersCount()
        {
            var suppliersCountViewModel = new SuppliersCountViewModel();

            suppliersCountViewModel.SuppliersCount = _supplierRepository.List().Count;

            return PartialView(suppliersCountViewModel);
        }
    }
}