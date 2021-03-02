using AdminWebPanel.Models;
using System.Web.Mvc;

namespace AdminWebPanel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BaseModel model=new BaseModel();
            model.LoginControl();

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
