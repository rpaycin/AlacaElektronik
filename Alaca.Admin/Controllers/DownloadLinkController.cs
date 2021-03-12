using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Admin.Entity;
using Admin.Models.Helper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Alaca.Admin.Controllers
{
    public class DownloadLinkController : Controller
    {
        private readonly IDownloadLinkData _downloadLinkData;

        public DownloadLinkController()
        {
            _downloadLinkData = new DownloadLinkData();
        }

        public ActionResult Index()
        {
            List<DownloadLink> downloadLinks = _downloadLinkData.GetDownloadLinks();

            return View(downloadLinks);
        }

        [HttpPost]
        public JsonResult UpdateDownloadLink(DownloadLink downloadLink)
        {
            _downloadLinkData.UpdateDownloadLink(downloadLink);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveDownloadLink(DownloadLink downloadLink)
        {
            if (Session[Constants.SessionInformation] != null)
            {
                var user = (User)Session[Constants.SessionInformation];
                downloadLink.CreateUser = user.Id;
            }
            _downloadLinkData.SaveDownloadLink(downloadLink);

            return Json(new Response { ErrorMessage = "Kaydedilmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDownloadLink(DownloadLink downloadLink)
        {
            _downloadLinkData.DeleteDownloadLink(downloadLink.DownloadId);

            return Json(new Response { ErrorMessage = "Silinmiştir", IsSuccess = false }, JsonRequestBehavior.AllowGet);
        }
    }
}