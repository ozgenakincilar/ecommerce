using Autofac;
using NS.Business.Advertisements;
using NS.Business.Cart;
using NS.Business.Categories;
using NS.Business.Collections;
using NS.Business.Helpers.ListHelpers;
using NS.Business.Products;
using NS.Business.Suppliers;
using NS.Orm;

namespace NS.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NorthwindEntities>().InstancePerRequest();
            builder.RegisterType<AdvertisementRepository>().As<IAdvertisementRepository>().InstancePerRequest();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerRequest();
            builder.RegisterType<CollectionRepository>().As<ICollectionRepository>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>().InstancePerRequest();
            builder.RegisterType<CategoryListHelper>().As<ICategoryListHelper>().InstancePerRequest();
            builder.RegisterType<SupplierListHelper>().As<ISupplierListHelper>().InstancePerRequest();
            builder.RegisterType<CartOperations>().As<ICartOperations>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
