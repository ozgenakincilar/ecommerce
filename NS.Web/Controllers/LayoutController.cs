using System.Web.Mvc;

namespace NS.Web.Controllers
{
    public class LayoutController : Controller
    {
        public ActionResult RegistrationHeaderTop()
        {
            return PartialView();
        }

        public ActionResult TopNavigationBar()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Copyright()
        {
            return PartialView();
        }
    }
}