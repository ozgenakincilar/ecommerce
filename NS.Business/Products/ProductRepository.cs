using System.Collections.Generic;
using NS.Orm;
using System.Linq;
using System;
using NS.Infrastructure.Paging;

namespace NS.Business.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindEntities _northwindEntityDataModel;
        public ProductRepository(NorthwindEntities northwindEntityDataModel)
        {
            _northwindEntityDataModel = northwindEntityDataModel;
        }

        public Product Load(int id)
        {
            return _northwindEntityDataModel.Products.FirstOrDefault(x => x.ProductID == id);
        }

        public IList<Product> RelatedProducts(int? categoryId, int? productId, decimal? unitPrice)
        {
            var criteria = new ProductSearchCriteria();

            if (categoryId.HasValue)
            {
                criteria.SelectedCategories = new List<string>();

                criteria.SelectedCategories.Add(categoryId.ToString());
            }

            var productsInCategory = Search(criteria).SearchList.ToList();

            var relatedProducts = productsInCategory.Where(x => x.ProductID != productId)
                                                    .OrderBy(x => Guid.NewGuid())
                                                    .Take(3)
                                                    .ToList();

            return relatedProducts;
        }

        public PagedSearchList<Product> Search(IProductSearchCriteria productSearch)
        {
            var productsQuery = _northwindEntityDataModel.Products.AsQueryable();

            if (productSearch.Id.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.ProductID == productSearch.Id.Value);
            }

            if (productSearch.SelectedCategories != null && productSearch.SelectedCategories.Any())
            {
                productsQuery = productsQuery.Where(x => productSearch.SelectedCategories.Contains(x.CategoryID.ToString()));
            }

            if (productSearch.SelectedSuppliers != null && productSearch.SelectedSuppliers.Any())
            {
                productsQuery = productsQuery.Where(x => productSearch.SelectedSuppliers.Contains(x.SupplierID.ToString()));
            }

            if (!string.IsNullOrEmpty(productSearch.SearchTerm))
            {
                productsQuery = productsQuery.Where(x => x.ProductName.ToLower().Contains(productSearch.SearchTerm.ToLower()));
            }

            if (productSearch.IsInStock)
            {
                productsQuery = productsQuery.Where(x => x.UnitsInStock.HasValue && x.UnitsInStock.Value > 0);
            }

            if (productSearch.IsContinued)
            {
                productsQuery = productsQuery.Where(x => !x.Discontinued);
            }

            if (productSearch.MinUnitPrice.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.UnitPrice.HasValue
                                                        && x.UnitPrice.Value >= productSearch.MinUnitPrice);
            }

            if (productSearch.MaxUnitPrice.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.UnitPrice.HasValue
                                                        && x.UnitPrice.Value <= productSearch.MaxUnitPrice);
            }

            if (productSearch.PagedBase == null)
            {
                productSearch.PagedBase = new PagedBase();
                productSearch.PagedBase.PageIndex = 1;
                productSearch.PagedBase.PageSize = 10;
            }

            var pagedProducts = productsQuery.ToPage(productSearch.PagedBase);

            return pagedProducts;
        }

        public IList<Product> Showcase()
        {
            var productsQuery = _northwindEntityDataModel.Products.AsQueryable();

            var products = productsQuery.OrderByDescending(x => x.UnitsInStock).Take(20).ToList();

            return products;
        }
    }
}
