using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

namespace Alaca.Web.Controllers
{
    public class DuyuruHaberController : Controller
    {
        private readonly IFirmsData _firmsData;
        private readonly INewsData _newsData;

        public DuyuruHaberController()
        {
            _firmsData = new FirmsData();
            _newsData = new NewsData();
        }

        public ActionResult Detay(string Id)
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            DuyuruHaber news = _newsData.GetNew(Convert.ToInt32(Id));

            List<DuyuruHaber> newsFull = _newsData.GetNews();

            var newsModel = new NewsModel
            {
                DuyuruHaber = news,
                TumHaberler = newsFull
            };

            var layoutModel = new LayoutModel<NewsModel>(newsModel, firm);

            return View(layoutModel);
        }
    }
}