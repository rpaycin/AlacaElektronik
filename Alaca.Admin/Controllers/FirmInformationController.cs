using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Admin.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Alaca.Admin.Controllers
{
    public class FirmInformationController : Controller
    {
        private readonly IFirmsData _firmsData;

        public FirmInformationController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index()
        {
            List<FirmaBilgileri> firms = _firmsData.GetFirms();

            return View(firms);
        }

        [HttpPost]
        public JsonResult UpdateFirm(FirmaBilgileri firma)
        {
            _firmsData.UpdateFirm(firma);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveFirm(FirmaBilgileri firma)
        {
            _firmsData.SaveFirm(firma);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteFirm(FirmaBilgileri firma)
        {
            _firmsData.DeleteFirm(firma.Id);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}