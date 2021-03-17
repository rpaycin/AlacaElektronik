using Admin.DataLayer.LoginData;
using Admin.Entity;
using Admin.Models.Helper;
using AdminWebPanel.Models;
using System.Web.Mvc;

namespace AdminWebPanel.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginData _loginData;

        public LoginController()
        {
            _loginData = new LoginData();
        }

        public ActionResult Index()
        {
            return View(new LoginModel { IsValid = true });
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            LoginModel model = new LoginModel { IsValid = ModelState.IsValid };

            Response response = _loginData.LoginControl(user);

            if (response.IsSuccess)
            {
                Session[Constants.SessionInformation] = (User)response.Data[0];

                return RedirectToAction("Index", "Home");
            }

            model.IsValid = false;
            model.ErrorMessage = response.ErrorMessage;

            return View(model);
        }

        //public JsonResult SendForgetMailAdres(string emailAddress)
        //{
        //    try
        //    {
        //        //Kullanıcı bilgileri serverdan alınıyor
        //        Response response = _loginBusiness.GetUserInfoByEmail(emailAddress.Trim());
        //        if (!response.IsSuccess || response.Data == null)
        //            return Json(response, JsonRequestBehavior.AllowGet);

        //        User user = (User)response.Data[0];
        //        string name = string.Format("{0} {1}", user.FirstName, user.LastName);

        //        //Mail gönderiliyor
        //        //string mailMessageBody = MailTemplates.GetInformationMailTemplate(name, emailAddress, user.Password);
        //        //bool isSend = Mail.SendMail(name, emailAddress, mailMessageBody);

        //        string errorMessage = !false ? string.Format("{0} adresinize mail yollanamadı!", emailAddress) : string.Empty;
        //        return Json(new Response { ErrorMessage = errorMessage, IsSuccess = false }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new Response { ErrorMessage = ex.Message, IsSuccess = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
