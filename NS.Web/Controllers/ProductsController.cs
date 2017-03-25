using AutoMapper;
using NS.Business.Cart;
using NS.Business.Helpers.ListHelpers;
using NS.Business.Products;
using NS.Web.Models.Products;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NS.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryListHelper _categoryListHelper;

        private readonly ISupplierListHelper _supplierListHelper;

        private readonly ICartOperations _cartOperations;

        public ProductsController(IProductRepository productRepository,
            ICategoryListHelper categoryListHelper,
            ISupplierListHelper supplierListHelper, ICartOperations cartOperations)
        {
            _productRepository = productRepository;
            _categoryListHelper = categoryListHelper;
            _supplierListHelper = supplierListHelper;
            _cartOperations = cartOperations;
        }

        public ActionResult Detail(int? id, string productName)
        {
            var productSearchCriteria = new ProductSearchCriteria()
            {
                Id = id
            };

            var productDetail = _productRepository
                                .Search(productSearchCriteria)
                                 .SearchList
                                 .Select(x => Mapper.Map<ProductDetailViewModel>(x))
                                .FirstOrDefault();

            return View(productDetail);
        }

        public ActionResult RelatedProducts(int? categoryId, decimal? unitPrice, int? productId)
        {
            if (!categoryId.HasValue)
                return new EmptyResult();

            if (!unitPrice.HasValue)
                return new EmptyResult();

            if (!productId.HasValue)
                return new EmptyResult();


            var relatedProducts = _productRepository
                                .RelatedProducts(categoryId, productId, unitPrice)
                                 .Select(x => Mapper.Map<ProductViewModel>(x)).ToList();

            return PartialView(relatedProducts);
        }

        public ActionResult ViewedProducts()
        {
            return PartialView();
        }

        [HttpGet]
        public ViewResult Search(ProductSearchCriteriaViewModel productSearchCriteriaViewModel)
        {
            var productSearchViewModel = new ProductSearchViewModel();

            productSearchViewModel.ProductSearchCriteria = productSearchCriteriaViewModel ?? new ProductSearchCriteriaViewModel();

            productSearchCriteriaViewModel.Categories = _categoryListHelper.Get(null);

            productSearchCriteriaViewModel.Suppliers = _supplierListHelper.Get(null);

            return View(productSearchViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(ProductSearchViewModel productSearchViewModel)
        {
            if (productSearchViewModel == null)
                productSearchViewModel = new ProductSearchViewModel();

            if (productSearchViewModel.ProductSearchCriteria == null)
                productSearchViewModel.ProductSearchCriteria = new ProductSearchCriteriaViewModel();

            productSearchViewModel.ProductSearchCriteria.Categories = _categoryListHelper.Get(productSearchViewModel.ProductSearchCriteria.SelectedCategories?.ToArray());

            productSearchViewModel.ProductSearchCriteria.Suppliers = _supplierListHelper.Get(productSearchViewModel.ProductSearchCriteria.SelectedSuppliers?.ToArray());

            var criteria = Mapper.Map<ProductSearchCriteria>(productSearchViewModel.ProductSearchCriteria);

            var products = _productRepository.Search(criteria);

            if (products == null || !products.SearchList.Any())
                return View(productSearchViewModel);

            productSearchViewModel.Products = products.SearchList.Select(x => Mapper.Map<ProductViewModel>(x)).ToList();

            productSearchViewModel.CurrentPageIndex = products.PageIndex;
            productSearchViewModel.PageSize = products.PageSize;
            productSearchViewModel.TotalItemCount = products.TotalItemCount;
            productSearchViewModel.TotalPageCount = (products.TotalItemCount / products.PageSize) + 1;

            return View(productSearchViewModel);
        }

        public ActionResult AddToCart(int? productId)
        {
            if (!productId.HasValue)
                return Redirect(Request.Url.AbsolutePath);

            return View(new AddToCartViewModel() { Quantity = 1, ProductId = productId.Value });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(AddToCartViewModel categoryViewModel)
        {
            var product = _productRepository.Load(categoryViewModel.ProductId);

            if (product == null)
                RedirectToAction("Index", "Cart");

            var cartItem = new CartItem()
            {
                PhotoUrl = product.ImageUrl,
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice.HasValue ? product.UnitPrice.Value : 0,
                Quantity = categoryViewModel.Quantity
            };

            _cartOperations.AddToCart(cartItem);

            return RedirectToAction("Index", "Cart");
        }
    }
}