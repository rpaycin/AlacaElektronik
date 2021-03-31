using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace Alaca.Web.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IFirmsData _firmsData;
        private readonly IDownloadLinkData _downloadLinkData;

        public DownloadController()
        {
            _firmsData = new FirmsData();
            _downloadLinkData = new DownloadLinkData();
        }

        public ActionResult Index()
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            List<DownloadLink> downloadLinks = _downloadLinkData.GetDownloadLinks();

            var downloadModel = new DownloadModel
            {
                Downloads = downloadLinks,
            };

            var layoutModel = new LayoutModel<DownloadModel>(downloadModel, firm);

            return View(layoutModel);
        }
    }
}