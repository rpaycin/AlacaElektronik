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
    public class NewsController : Controller
    {
        private readonly INewsData _newsData;

        public NewsController()
        {
            _newsData = new NewsData();
        }

        public ActionResult Index()
        {
            List<DuyuruHaber> news = _newsData.GetNews();

            return View(news);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult SaveNews()
        {
            NameValueCollection form = HttpContext.Request.Form;

            var news = new DuyuruHaber
            {
                DuyuruId = Convert.ToInt32(form["DuyuruId"]),
                DuyuruBaslik = form["DuyuruBaslik"],
                Duyuru = form["Duyuru"],
                DuyuruKisa = form["DuyuruKisa"],
                Aktif = Convert.ToBoolean(form["Aktif"]),
                Sira = !string.IsNullOrEmpty(form["Sira"]) ? Convert.ToInt32(form["Sira"]) : 0
            };

            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                news.CreateUser = user.Id;
            }

            if (Request.Files != null && Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];

                file.SaveAs(Server.MapPath("/Upload/NewsImage/" + file.FileName));

                news.ImageUrl = file.FileName;
            }

            if (news.DuyuruId <= 0)
            {
                _newsData.SaveNews(news);
            }
            else
            {
                _newsData.UpdateNews(news);
            }

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteNews(DuyuruHaber news)
        {
            _newsData.DeleteNews(news.DuyuruId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}