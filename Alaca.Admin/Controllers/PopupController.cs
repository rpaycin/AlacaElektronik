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
    public class PopupController : Controller
    {
        private readonly IPopupData _popupData;

        public PopupController()
        {
            _popupData = new PopupData();
        }

        public ActionResult Index()
        {
            List<Popup> popups = _popupData.GetPopups();

            return View(popups);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult SavePopup()
        {
            NameValueCollection form = HttpContext.Request.Form;

            var popup = new Popup
            {
                PopupId = Convert.ToInt32(form["PopupId"]),
                Popup1 = form["Popup"],
                Aktif = Convert.ToBoolean(form["Aktif"]),
                Sira = !string.IsNullOrEmpty(form["Sira"]) ? Convert.ToInt32(form["Sira"]) : 0
            };
            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                popup.CreateUser = user.Id;
            }

            if (popup.PopupId <= 0)
            {
                _popupData.SavePopup(popup);
            }
            else
            {
                _popupData.UpdatePopup(popup);
            }

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletePopup(Popup popup)
        {
            _popupData.DeletePopup(popup.PopupId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}