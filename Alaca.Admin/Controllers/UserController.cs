using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Admin.Entity;
using Admin.Models.Helper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Alaca.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData _userData;

        public UserController()
        {
            _userData = new UserData();
        }

        public ActionResult Index()
        {
            List<Kullanicilar> User = _userData.GetUsers();

            return View(User);
        }

        [HttpPost]
        public JsonResult UpdateUser(Kullanicilar user)
        {
            _userData.UpdateUser(user);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUser(Kullanicilar user)
        {
            if (Session[Constants.SessionInformation] != null)
            {
                var userSession = (User)Session[Constants.SessionInformation];
                user.CreateUser = userSession.Id;
            }
            _userData.SaveUser(user);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser(Kullanicilar user)
        {
            _userData.DeleteUser(user.KullaniciId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}