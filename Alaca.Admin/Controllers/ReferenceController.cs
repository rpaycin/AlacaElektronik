using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Admin.Entity;
using Admin.Models.Helper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Alaca.Admin.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly IReferenceData _referenceData;

        public ReferenceController()
        {
            _referenceData = new ReferenceData();
        }

        public ActionResult Index()
        {
            List<Referans> Reference = _referenceData.GetReferences();

            return View(Reference);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult SaveReference()
        {
            NameValueCollection form = HttpContext.Request.Form;

            var reference = new Referans
            {
                ReferansId = Convert.ToInt32(form["ReferansId"]),
                ReferansFirmaAdi = form["ReferansFirmaAdi"],
                FirmaUrl = form["FirmaUrl"],
                Aktif = form["Aktif"] == "on",
                Sira = !string.IsNullOrEmpty(form["Sira"]) ? Convert.ToInt32(form["Sira"]) : 0
            };

            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                reference.CreateUser = user.Id;
            }

            if (Request.Files != null && Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];

                file.SaveAs(Server.MapPath("/Upload/ReferenceImage/" + file.FileName));

                reference.ResimUrl = file.FileName;
            }

            if (reference.ReferansId <= 0)
            {
                _referenceData.SaveReference(reference);
            }
            else
            {
                _referenceData.UpdateReference(reference);
            }

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteReference(Referans reference)
        {
            _referenceData.DeleteReference(reference.ReferansId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}