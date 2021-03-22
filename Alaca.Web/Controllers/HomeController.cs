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

        public HomeController()
        {
            _firmsData = new FirmsData();
            _referenceData = new ReferenceData();
        }

        public ActionResult Index()
        {
            // home model
            List<Referans> references = _referenceData.GetSliderReferences();

            var homeModel = new HomeModel
            {
                References = references
            };

            //layout model
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel<HomeModel>(homeModel, firm);

            return View(layoutModel);
        }
    }
}