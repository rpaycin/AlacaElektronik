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
    public class CustomerWritingController : Controller
    {
        private readonly ICustomerWritingData _customerWritingData;

        public CustomerWritingController()
        {
            _customerWritingData = new CustomerWritingData();
        }

        public ActionResult Index()
        {
            List<MusteriYazi> CustomerWriting = _customerWritingData.GetCustomerWritings();

            return View(CustomerWriting);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult SaveCustomerWriting()
        {
            NameValueCollection form = HttpContext.Request.Form;

            var customerWriting = new MusteriYazi
            {
                MusteriYaziId = Convert.ToInt32(form["MusteriYaziId"]),
                Isim = form["Isim"],
                Unvan = form["Unvan"],
                MusteriYazi1 = form["MusteriYazi"],
                FirmaUrl = form["FirmaUrl"],
                Sira = !string.IsNullOrEmpty(form["Sira"]) ? Convert.ToInt32(form["Sira"]) : 0
            };

            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                customerWriting.CreateUser = user.Id;
            }

            if (Request.Files != null && Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];

                file.SaveAs(Server.MapPath("/Upload/CustomerWritingImage/" + file.FileName));

                customerWriting.ResimUrl = file.FileName;
            }

            if (customerWriting.MusteriYaziId <= 0)
            {
                _customerWritingData.SaveCustomerWriting(customerWriting);
            }
            else
            {
                _customerWritingData.UpdateCustomerWriting(customerWriting);
            }

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCustomerWriting(MusteriYazi customerWriting)
        {
            _customerWritingData.DeleteCustomerWriting(customerWriting.MusteriYaziId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}