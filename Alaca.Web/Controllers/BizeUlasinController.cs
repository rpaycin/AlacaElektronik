using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Helper;
using Alaca.Web.Models;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
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
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            NameValueCollection form = HttpContext.Request.Form;

            string body = string.Format("Mail Adresi: {0}, İçerik:{1}", form["EPosta"], form["Mesaj"]);

            EmailSender.Send("Bize Ulaşın", body, firm.IletisimMail);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}