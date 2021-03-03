using System.Web.Mvc;

namespace AdminWebPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FirmInformation()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon(); 
            return RedirectToAction("Index", "Login");
        }
    }
}
