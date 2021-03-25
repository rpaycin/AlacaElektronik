using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class HizmetlerimizController : Controller
    {
        private readonly IFirmsData _firmsData;

        public HizmetlerimizController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index(string Id)
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var serviceModel = new ServiceModel
            {
                SelectedId = Id
            };

            var layoutModel = new LayoutModel<ServiceModel>(serviceModel, firm);

            return View(layoutModel);
        }
    }
}