using System.Web.Mvc;

namespace NS.Web.Areas.Administration.Controllers
{
    public class ManageProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return new EmptyResult();
        }
    }
}