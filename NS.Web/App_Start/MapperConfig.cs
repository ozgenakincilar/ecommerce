using AutoMapper;
using NS.Business.Cart;
using NS.Business.Products;
using NS.Orm;
using NS.Web.Models.Cart;
using NS.Web.Models.Categories;
using NS.Web.Models.Home;
using NS.Web.Models.Products;
using BO = NS.Web.Areas.Administration.Models.Categories;

namespace NS.Web
{
    public class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CartItemViewModel, CartItem>().ReverseMap();

                config.CreateMap<CategoryViewModel, Category>().ReverseMap();
                config.CreateMap<BO.CategoryViewModel, Category>().ReverseMap();

                config.CreateMap<ProductViewModel, Product>().ReverseMap();

                config.CreateMap<AdvertisementViewModel, Advertisement>().ReverseMap();

                config.CreateMap<CollectionViewModel, Collection>().ReverseMap();

                config.CreateMap<ProductDetailViewModel, Product>().ReverseMap();

                config.CreateMap<ProductSearchCriteriaViewModel, ProductSearchCriteria>().ReverseMap();
            });
        }
    }
}