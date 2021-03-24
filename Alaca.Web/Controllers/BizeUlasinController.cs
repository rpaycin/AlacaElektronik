using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class BizeUlasinController : Controller
    {
        private readonly IFirmsData _firmsData;

        public BizeUlasinController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index()
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel(firm);
            
            return View(layoutModel);
        }

        [HttpPost]
        public JsonResult SendEmail()
        {
            NameValueCollection form = HttpContext.Request.Form;

            string nameSurname = form["AdSoyad"];
            string emailAddress = form["EPosta"];
            string subject = form["Konu"];
            string message = form["Mesaj"];

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}