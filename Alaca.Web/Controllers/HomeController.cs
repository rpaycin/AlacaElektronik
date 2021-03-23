using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFirmsData _firmsData;
        private readonly IReferenceData _referenceData;
        private readonly ICustomerWritingData _customerWritingData;
        private readonly INewsData _newsData;

        public HomeController()
        {
            _firmsData = new FirmsData();
            _referenceData = new ReferenceData();
            _customerWritingData = new CustomerWritingData();
            _newsData = new NewsData();
        }

        public ActionResult Index()
        {
            // home model
            List<Referans> references = _referenceData.GetSliderReferences();

            List<MusteriYazi> customerWritings = _customerWritingData.GetCustomerWritings();

            List<DuyuruHaber> news = _newsData.GetNews();

            var homeModel = new HomeModel
            {
                References = references,
                CustomerWritings = customerWritings,
                News = news
            };

            //layout model
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel<HomeModel>(homeModel, firm);

            return View(layoutModel);
        }
    }
}