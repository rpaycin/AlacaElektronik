using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class UrunlerimizController : Controller
    {
        private readonly IFirmsData _firmsData;

        public UrunlerimizController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index(string seletedTab)
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var productModel = new ProductModel
            {
                SelectedTab = seletedTab
            };

            var layoutModel = new LayoutModel<ProductModel>(productModel, firm);

            return View(layoutModel);
        }
    }
}