using NS.Infrastructure.Paging;
using NS.Orm;
using System.Collections.Generic;

namespace NS.Business.Products
{
    public interface IProductRepository
    {
        PagedSearchList<Product> Search(IProductSearchCriteria productSearch);

        Product Load(int id);
        IList<Product> Showcase();
        IList<Product> RelatedProducts(int? categoryId, int? productId, decimal? unitPrice);
    }
}
