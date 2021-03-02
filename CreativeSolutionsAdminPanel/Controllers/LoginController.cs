using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.BusinessLayer.Login;
using AdminWebPanel.Models;
using Admin.Entity;
using Admin.BusinessLayer.LookupList;

namespace AdminWebPanel.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginBusiness _loginBusiness;
        private readonly ILookupListBusiness _lookupListBusiness;

        public LoginController()
        {
            _lookupListBusiness = new LookupListBusiness();
            _loginBusiness = new LoginBusiness();
        }

        public ActionResult Index()
        {
            //Firma listesini çekme
            if (CacheLookup.ListFirm == null || CacheLookup.ListFirm.Count == 0)
            {
                Response lookupListResponse = _lookupListBusiness.GetFirmList();
                if (lookupListResponse.IsSuccess && lookupListResponse.Data.Length > 0)
                    CacheLookup.ListFirm = (new BaseModel()).GetDropdownList((List<OptionList>)lookupListResponse.Data[0], null);
            }

            return View(new LoginModel { IsValid = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            LoginModel model = new LoginModel { IsValid = ModelState.IsValid };

            if (ModelState.IsValid)
            {
                //Kullanıcı kontrol
                Response response = _loginBusiness.LoginControl(user);
                if (response.IsSuccess)
                {
                    model.User = (User)response.Data[0];
                    //özel kullanıcı ise şirket seçimi yapılcak
                    if (model.User.IsSpecialUser == 1)
                    {
                        if (user.FirmID < 1)
                        {
                            model.ListFirm = CacheLookup.ListFirm;
                            return View(model);
                        }
                        else
                            model.User.FirmID = user.FirmID;
                    }

                    Session["UserInfo"] = model.User;

                    return RedirectToAction("Index", "Home");
                }
                model.IsValid = false;
                model.ErrorMessage = response.ErrorMessage;
            }
            return View(model);
        }

        public JsonResult SendForgetMailAdres(string emailAddress)
        {
            try
            {
                //Kullanıcı bilgileri serverdan alınıyor
                Response response = _loginBusiness.GetUserInfoByEmail(emailAddress.Trim());
                if (!response.IsSuccess || response.Data == null)
                    return Json(response, JsonRequestBehavior.AllowGet);

                User user = (User)response.Data[0];
                string name = string.Format("{0} {1}", user.FirstName, user.LastName);

                //Mail gönderiliyor
                //string mailMessageBody = MailTemplates.GetInformationMailTemplate(name, emailAddress, user.Password);
                //bool isSend = Mail.SendMail(name, emailAddress, mailMessageBody);

                string errorMessage = !false ? string.Format("{0} adresinize mail yollanamadı!", emailAddress) : string.Empty;
                return Json(new Response { ErrorMessage = errorMessage, IsSuccess = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Response { ErrorMessage = ex.Message, IsSuccess = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
