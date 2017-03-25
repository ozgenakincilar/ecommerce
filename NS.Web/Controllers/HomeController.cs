using AutoMapper;
using NS.Business.Advertisements;
using NS.Business.Collections;
using NS.Business.Products;
using NS.Infrastructure.Logging;
using NS.Web.Models.Home;
using NS.Web.Models.Products;
using System.Linq;
using System.Web.Mvc;

namespace NS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        private readonly IProductRepository _productRepository;

        private readonly ICollectionRepository _collectionRepository;

        private readonly ILoggingManager _loggingManager;

        public HomeController(IAdvertisementRepository advertisementRepository, IProductRepository productRepository, ICollectionRepository collectionRepository, ILoggingManager loggingManager)
        {
            _advertisementRepository = advertisementRepository;
            _productRepository = productRepository;
            _collectionRepository = collectionRepository;
            _loggingManager = loggingManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomePageSlider()
        {
            var advertisements = _advertisementRepository.GetActiveAdvertisements()
                                                         .Select(Mapper.Map<AdvertisementViewModel>)
                                                         .ToList();

            return PartialView(advertisements);
        }

        public ActionResult Showcase()
        {
            var products = _productRepository.Showcase().Select(Mapper.Map<ProductViewModel>).ToList();

            return PartialView(products);
        }

        public ActionResult FooterSlider()
        {
            var collections = _collectionRepository.GetActiveCollections()
                                                   .Select(Mapper.Map<CollectionViewModel>)
                                                   .ToList();
            return PartialView(collections);
        }


    }
}